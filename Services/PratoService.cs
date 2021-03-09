using api.Models;
using api.Services.Interfaces;
using api.Repositories.Interfaces;
using System.Threading.Tasks;
using api.Validators.Interfaces;

namespace api.Services {
    public class PratoService : IPratoService {
        private readonly IPratoRepository repository;
        private readonly IPratoValidator validator;
        public PratoService(
            IPratoRepository repository,
            IPratoValidator validator
        ) {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<Prato[]> ListarAsync() {
            return await repository.ListarAsync();
        }

        public async Task CadastrarAsync(Prato prato) {
            
            await repository.CadastrarAsync(prato);
        }

        public async Task EditarAsync(Prato prato) {
            await repository.EditarAsync(prato);
        }
    }
}