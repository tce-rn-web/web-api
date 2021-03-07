namespace api.Models {
    public class Usuario {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public Usuario() {
            this.Id = 0;
            this.Email = "";
            this.Senha = "";
            this.Nome = "";
        }

        public Usuario(int id, string email, string senha, string nome) {
            this.Id = id;
            this.Email = email;
            this.Senha = senha;
            this.Nome = nome;
        }
    }
}