namespace api.Models {
    public class PedidoPrato {
        public int IdPedido { get; set; }
        public int IdPrato { get; set; }

        public PedidoPrato() {
            this.IdPedido = 0;
            this.IdPrato = 0;
        }

        public PedidoPrato(int idPedido, int idPrato) {
            this.IdPedido = idPedido;
            this.IdPrato = idPrato;
        }
    }
}