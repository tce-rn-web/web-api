using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces {
    public interface IPedidoRepository {
        Task<Pedido[]> ListarAsync(int idEstado);
        Task CadastrarAsync(Pedido pedido);
    }
}