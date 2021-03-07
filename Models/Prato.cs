namespace api.Models {
    public class Prato {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public Prato() {
            this.Id = 0;
            this.Nome = "";
            this.Preco = 0.0f;
        }

        public Prato(int id, string nome, float preco) {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}