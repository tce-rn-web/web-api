using api.Models;
using System.Threading.Tasks;

namespace api.Services.Interfaces {
    public interface IPedidoService {
        Task<Pedido[]> ListarAsync(int estadoPedidoId);
        Task CadastrarAsync(Pedido pedido, Prato[] pratos);
    }
}