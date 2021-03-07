namespace api.Models {

    public class Cargo {
        public static readonly int DONO = 1;
        public static readonly int FUNCIONARIO = 2;

        public int Id { get; set; }
        public string Descricao { get; set; }

        public Cargo() {
            this.Id = 0;
            this.Descricao = "";
        }

        public Cargo(int id, string descricao) {
            this.Id = id;
            this.Descricao = descricao;
        }
    }
}