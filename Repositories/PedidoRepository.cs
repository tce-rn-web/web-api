using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories {
    public class PedidoRepository : IPedidoRepository {
        private readonly DatabaseContext context;
        public PedidoRepository(DatabaseContext context) {
            this.context = context;
        }

        public async Task<Pedido[]> ListarAsync(int estadoPedidoId, bool incluirPratos) {
            IQueryable<Pedido> query = this.context.Pedidos;
            
            if(incluirPratos)
                query = query
                    .Include(p => p.PedidosPratos)
                    .ThenInclude(pp => pp.Prato);

            query = query.AsNoTracking()
                    .OrderBy<Pedido, int>(pedido => pedido.Id);
            if(estadoPedidoId > 0)
                query = query
                    .Where<Pedido>(pedido => pedido.EstadoPedidoId == estadoPedidoId);
            
            return await query.ToArrayAsync();
        }

        public async Task<Pedido> EncontrarPorIdAsync(int id, bool incluirPratos) {
            IQueryable<Pedido> query = this.context.Pedidos;

            if(incluirPratos)
                query = query
                    .Include(p => p.PedidosPratos)
                    .ThenInclude(pp => pp.Prato);

            query.AsNoTracking<Pedido>()
                .OrderBy<Pedido, int>(p => p.Id)
                .Where<Pedido>(p => p.Id == id);

            return await query.FirstOrDefaultAsync<Pedido>();
        }

        public async Task CadastrarAsync(Pedido pedido) {
            var pedidosPratos = pedido.PedidosPratos;
            pedido.PedidosPratos = null;

            foreach(var pp in pedidosPratos) {
                pp.PedidoId = 0;
                pp.Pedido = pedido;
                this.context.Add(pp);
            }
            
            if(await this.context.SaveChangesAsync() <= 0)
                // TODO: Verificar em que situações isso ocorre
                throw new System.Exception();
        }

        public async Task EditarAsync(Pedido pedido) {
            // Busca pedido atual
            var pedidoAtual = await this.EncontrarPorIdAsync(pedido.Id, false);

            if(pedidoAtual == null || pedidoAtual.Id <= 0)
                // TODO: criar uma exceção
                throw new System.Exception("O pedido informado não está cadastrado.");

            // Remove os PedidosPratos que atuais
            foreach(var pp in pedidoAtual.PedidosPratos)
                this.context.Remove<PedidoPrato>(pp);

            // Adiciona PedidosPratos novos
            foreach(var pp in pedido.PedidosPratos) {
                pp.PedidoId = pedido.Id;
                this.context.Add(pp);
            }

            // Atualiza campos do pedido
            pedido.DataDoPedido = pedidoAtual.DataDoPedido;
            this.context.Update<Pedido>(pedido);
            
            if(await this.context.SaveChangesAsync() <= 0)
                // TODO: Verificar em que situações isso ocorre
                throw new System.Exception();
        }

        public async Task AlterarEstadoPedidoAsync(int id, int estadoPedidoId) {
            // Pedido pedido = new Pedido(id, null, null, estadoPedidoId, null);
            Pedido pedido = await this.context.Pedidos
                .OrderBy<Pedido,int>(p => p.Id)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(pedido == null | pedido.Id <= 0)
                // TODO: criar uma exceção para aqui
                throw new System.Exception("O id de pedido informado não está cadastrado.");

            pedido.EstadoPedidoId = estadoPedidoId;
            
            if(await this.context.SaveChangesAsync() <= 0)
                // TODO: Verificar em que situações isso ocorre
                throw new System.Exception();
        }
    }
}