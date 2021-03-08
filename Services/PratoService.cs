using api.Models;
using api.Services.Interfaces;
using api.Repositories.Interfaces;
using System.Threading.Tasks;

namespace api.Services {
    public class PratoService : IPratoService {
        private readonly IPratoRepository repository;
        public PratoService(IPratoRepository repository) {
            this.repository = repository;
        }

        public async Task<Prato[]> ListarAsync() {
            return await repository.ListarAsync();
        }
    }
}