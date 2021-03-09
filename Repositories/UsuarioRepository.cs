using api.Data;
using api.Exceptions;
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
                throw new FalhaCadastroUsuarioException();
        }

        public async Task<Usuario> EncontrarPorEmailAsync(string email) {
            IQueryable<Usuario> query = this.context.Usuarios;

            query = query.AsNoTracking()
                .OrderBy<Usuario, int>(u => u.Id)
                .Where<Usuario>(usuario => usuario.Email == email);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario[]> ListarAsync() {
            return await this.context.Usuarios
                .AsNoTracking()
                .OrderBy<Usuario, string>(p => p.Nome)
                .ToArrayAsync();
        }

        public async Task EditarAsync(Usuario usuario) {
            Usuario usuarioAtual = await this.context.Usuarios
                .OrderBy<Usuario, int>(p => p.Id)
                .FirstOrDefaultAsync(p => p.Id == usuario.Id);

            if(usuarioAtual == null || usuarioAtual.Id <= 0)
                throw new UsuarioIdNaoCadastradoException();

            usuarioAtual.Email = usuario.Email;
            usuarioAtual.Nome = usuario.Nome;
            usuarioAtual.Senha = usuario.Senha;
            usuarioAtual.CargoId = usuario.CargoId;
            
            await this.context.SaveChangesAsync();
        }
    }
}