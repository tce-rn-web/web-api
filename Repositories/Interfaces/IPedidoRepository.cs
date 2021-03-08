using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces {
    public interface IPedidoRepository {
        Task<Pedido[]> ListarAsync(int estadoPedidoId, bool incluirPratos);
        Task<Pedido> EncontrarPorIdAsync(int id, bool incluirPratos);
        Task CadastrarAsync(Pedido pedido);
        Task EditarAsync(Pedido pedido);
        Task AlterarEstadoPedidoAsync(int id, int estadoPedidoId);
    }
}