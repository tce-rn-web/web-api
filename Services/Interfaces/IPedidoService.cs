using api.Models;
using System.Threading.Tasks;

namespace api.Services.Interfaces {
    public interface IPedidoService {
        Task<Pedido[]> ListarAsync(int estadoPedidoId, bool incluirPratos);
        Task<Pedido> EncontrarPorIdAsync(int id, bool incluirPratos);
        Task CadastrarAsync(Pedido pedido);
        Task EditarAsync(Pedido pedido);
        Task AlterarEstadoPedidoAsync(int id, int estadoPedidoId);
    }
}