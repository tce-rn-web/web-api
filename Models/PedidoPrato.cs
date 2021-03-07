namespace api.Models {
    public class PedidoPrato {
        public int PedidoId { get; set; }
        public int PratoId { get; set; }
        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }
        public Prato Prato { get; set; }

        public PedidoPrato() {
            this.PedidoId = 0;
            this.PratoId = 0;
            this.Quantidade = 0;
        }

        public PedidoPrato(int pedidoId, int pratoId, int quantidade) {
            this.PedidoId = pedidoId;
            this.PratoId = pratoId;
            this.Quantidade = quantidade;
        }
    }
}