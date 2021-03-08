using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
    }
}