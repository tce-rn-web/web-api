using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Exceptions;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories {
    public class PratoRepository : IPratoRepository {
        private readonly DatabaseContext context;
        public PratoRepository(DatabaseContext context) {
            this.context = context;
        }

        public async Task<Prato[]> ListarAsync() {
            return await this.context.Pratos
                .AsNoTracking()
                .OrderBy<Prato, int>(p => p.Id)
                .ToArrayAsync<Prato>();
        }

        public async Task CadastrarAsync(Prato prato) {
            this.context.Add<Prato>(prato);

            if(await this.context.SaveChangesAsync() <= 0)
                throw new FalhaCadastroPratoException();
        }

        public async Task EditarAsync(Prato prato) {
            Prato pratoAtual = await this.context.Pratos
                .OrderBy<Prato,int>(p => p.Id)
                .FirstOrDefaultAsync(p => p.Id == prato.Id);

            if(pratoAtual == null || pratoAtual.Id <= 0)
                throw new PratoIdNaoCadastradoException();

            pratoAtual.Nome = prato.Nome;
            pratoAtual.Preco = prato.Preco;
            
            await this.context.SaveChangesAsync();
        }
    }
}