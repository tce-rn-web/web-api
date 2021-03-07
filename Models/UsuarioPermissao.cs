namespace api.Models {
    public class UsuarioPermissao {
        public int IdUsuario { get; set; }
        public int IdPermissao { get; set; }

        public UsuarioPermissao() {
            this.IdUsuario = 0;
            this.IdPermissao = 0;
        }
        public UsuarioPermissao(int idUsuario, int idPermissao) {
            this.IdUsuario = idUsuario;
            this.IdPermissao = idPermissao;
        }
    }
}