using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories {
    public class UsuarioRepository : IUsuarioRepository {
        private readonly DatabaseContext context;

        public UsuarioRepository(DatabaseContext context) {
            this.context = context;
        }
        
        public async Task CadastrarAsync(Usuario usuario) {
            this.context.Add(usuario);
            if(await this.context.SaveChangesAsync() <= 0)
                // TODO: Verificar em que situações isso ocorre
                throw new System.Exception();
        }

        public async Task<Usuario> EncontrarPorEmailAsync(string email) {
            IQueryable<Usuario> query = this.context.Usuarios;

            query = query.AsNoTracking()
                .Where<Usuario>(usuario => usuario.Email == email);

            return await query.FirstOrDefaultAsync();
        }
    }
}