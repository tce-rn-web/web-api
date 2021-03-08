using System.Collections.Generic;

namespace api.Models {
    public class EstadoPedido {
        public static readonly int CADASTRADO = 1;
        public static readonly int CANCELADO = 2;
        public static readonly int PREPARANDO = 3;
        public static readonly int PREPARADO = 4;
        public static readonly int ENTREGANDO = 5;
        public static readonly int ENTREGUE = 6;
        public static readonly int FINALIZADO = 7;

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

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