namespace api.Models {
    public class Usuario {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public int IdCargo { get; set; }

        public Usuario() {
            this.Id = 0;
            this.Email = "";
            this.Senha = "";
            this.Nome = "";
            this.IdCargo = 0;
        }

        public Usuario(int id, string email, string senha, string nome, int idCargo) {
            this.Id = id;
            this.Email = email;
            this.Senha = senha;
            this.Nome = nome;
            this.IdCargo = idCargo;
        }
    }
}