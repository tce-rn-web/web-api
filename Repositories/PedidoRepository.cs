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

        public async Task<Pedido[]> ListarAsync(int idEstado) {
            IQueryable<Pedido> query = this.context.Pedidos;
            
            query = query.AsNoTracking()
                    .OrderBy<Pedido, int>(pedido => pedido.Id);
            if(idEstado > 0)
                query = query
                    .Where<Pedido>(pedido => pedido.IdEstado == idEstado);
            return await query.ToArrayAsync();
        }

        public async Task CadastrarAsync(Pedido pedido) {
            var res = this.context.Add(pedido);
            if(await this.context.SaveChangesAsync() <= 0)
                // TODO: Verificar em que situações isso ocorre
                throw new System.Exception();
        }
    }
}