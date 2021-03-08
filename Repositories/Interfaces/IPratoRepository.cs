using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces {
    public interface IPratoRepository {
        Task<Prato[]> ListarAsync();
    }
}