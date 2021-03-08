using api.Models;
using System.Threading.Tasks;

namespace api.Services.Interfaces {
    public interface IPedidoService {
        Task<Pedido[]> ListarAsync(int estadoPedidoId, bool incluirPratos);
        Task CadastrarAsync(Pedido pedido);
    }
}