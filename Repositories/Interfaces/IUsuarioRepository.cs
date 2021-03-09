using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces {
    public interface IUsuarioRepository {
        Task CadastrarAsync(Usuario usuario);
        Task<Usuario> EncontrarPorEmailAsync(string email);
        Task<Usuario[]> ListarAsync();
        Task EditarAsync(Usuario usuario);
    }
}