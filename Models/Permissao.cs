namespace api.Models {
    public class Permissao {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Permissao() {
            this.Id = 0;
            this.Descricao = "";
        }

        public Permissao(int id, string descricao) {
            this.Id = id;
            this.Descricao = descricao;
        }
    }
}