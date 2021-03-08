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

        public async Task CadastrarAsync(Pedido pedido) {
            var pedidosPratos = pedido.PedidosPratos;
            pedido.PedidosPratos = null;

            Pedido res = this.context.Add(pedido).Entity;
            foreach(var pp in pedidosPratos) {
                pp.PedidoId = res.Id;
                this.context.Add(pp);
            }
            
            if(await this.context.SaveChangesAsync() <= 0)
                // TODO: Verificar em que situações isso ocorre
                throw new System.Exception();
        }
    }
}