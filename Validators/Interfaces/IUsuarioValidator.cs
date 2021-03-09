using api.Models;

namespace api.Validators.Interfaces {
    public interface IUsuarioValidator {
        void ValidarParaLogin(Usuario usuario);
        void ValidarParaCadastro(Usuario usuario);
        void ValidarParaEdicao(Usuario usuario);
    }
}