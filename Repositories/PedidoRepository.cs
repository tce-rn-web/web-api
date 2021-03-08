using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Exceptions;
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

            return await query.AsNoTracking<Pedido>()
                .OrderBy<Pedido, int>(p => p.Id)
                .Where<Pedido>(p => p.Id == id)
                .FirstOrDefaultAsync<Pedido>();
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
                throw new FalhaCadastroPedidoException();
        }

        public async Task EditarAsync(Pedido pedido) {
            Pedido pedidoAtual = await this.context.Pedidos
                .Include(p => p.PedidosPratos)
                .OrderBy<Pedido,int>(p => p.Id)
                .FirstOrDefaultAsync(p => p.Id == pedido.Id);

            if(pedidoAtual == null || pedidoAtual.Id <= 0)
                throw new PedidoIdNaoCadastradoException();

            // Remove os PedidosPratos que atuais
            foreach(var pp in pedidoAtual.PedidosPratos)
                this.context.Remove<PedidoPrato>(pp);

            // Adiciona PedidosPratos novos
            foreach(var pp in pedido.PedidosPratos) {
                pp.PedidoId = pedido.Id;
                pp.Pedido = null;
                pp.Prato = null;
                this.context.Add(pp);
            }

            // Atualiza campos do pedido
            pedidoAtual.Mesa = pedido.Mesa;
            pedidoAtual.Descricao = pedido.Descricao;
            pedidoAtual.EstadoPedidoId = pedido.EstadoPedidoId;
            
            await this.context.SaveChangesAsync();
        }

        public async Task AlterarEstadoPedidoAsync(int id, int estadoPedidoId) {
            Pedido pedido = await this.context.Pedidos
                .OrderBy<Pedido,int>(p => p.Id)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(pedido == null | pedido.Id <= 0)
                throw new PedidoIdNaoCadastradoException();

            pedido.EstadoPedidoId = estadoPedidoId;
            
            await this.context.SaveChangesAsync();
        }
    }
}