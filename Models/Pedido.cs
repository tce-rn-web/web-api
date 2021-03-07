using System;
using System.Collections.Generic;

namespace api.Models {
    public class Pedido {
        public int Id { get; set; } 
        public string Mesa { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDoPedido { get; set; }
        public int EstadoPedidoId { get; set; }
        public virtual EstadoPedido EstadoPedido { get; set; }
        public virtual IEnumerable<PedidoPrato> PedidosPratos { get; set; }

        public Pedido() {
            this.Id = 0;
            this.Mesa = "";
            this.EstadoPedidoId = 0;
            this.Descricao = "";
        }

        public Pedido(int id, string mesa, string descricao, int estadoPedidoId, DateTime? dataDoPedido) {
            this.Id = id;
            this.Mesa = mesa;
            this.EstadoPedidoId = estadoPedidoId;
            this.Descricao = descricao;
            this.DataDoPedido = dataDoPedido;
        }
    }
}