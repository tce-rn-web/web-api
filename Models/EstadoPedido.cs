using System.Collections.Generic;

namespace api.Models {
    public class EstadoPedido {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Pedido> Pedidos { get; set; }

        public EstadoPedido() {
            this.Id = 0;
            this.Nome = "";
        }
        
        public EstadoPedido(int id, string nome) {
            this.Id = id;
            this.Nome = nome;
        }
    }
}