using api.Models;
using api.Models.DTO;
using System.Threading.Tasks;

namespace api.Services.Interfaces {
    public interface IUsuarioService {
        Task CadastrarAsync(Usuario usuario);
        Task<TokenRespostaDTO> LoginAsync(Usuario usuario);
        Task<Usuario[]> ListarAsync();
        Task EditarAsync(Usuario usuario);
    }
}