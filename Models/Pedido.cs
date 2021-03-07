using System;

namespace api.Models {
    public class Pedido {
        public int Id { get; set; } 
        public string Mesa { get; set; }
        public string Descricao { get; set; }
        public int IdEstado { get; set; }
        public DateTime? DataDoPedido { get; set; }
        public PedidoPrato[] PedidosPratos { get; set; }

        public Pedido() {
            this.Id = 0;
            this.Mesa = "";
            this.Descricao = "";
            this.IdEstado = 0;
            this.DataDoPedido = null;
        }

        public Pedido(int id, string mesa, string descricao, int idEstado, DateTime? dataDoPedido) {
            this.Id = id;
            this.Mesa = mesa;
            this.Descricao = descricao;
            this.IdEstado = idEstado;
            this.DataDoPedido = dataDoPedido;
        }
    }
}