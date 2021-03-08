using System.Threading.Tasks;
using api.Models;

namespace api.Services.Interfaces {
    public interface IPratoService {
        Task<Prato[]> ListarAsync();
    }
}