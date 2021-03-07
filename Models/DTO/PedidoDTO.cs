using System;

namespace api.Models.DTO {
    public class PedidoDTO {
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Descricao { get; set; }
        public int EstadoPedidoId { get; set; }
        public DateTime? DataDoPedido { get; set; }
        public Prato[] Pratos { get; set; }

        public PedidoDTO() {
            this.Id = 0;
            this.Mesa = "";
            this.Descricao = "";
            this.EstadoPedidoId = 0;
            this.DataDoPedido = null;
            this.Pratos = null;
        }

        public PedidoDTO(
            int id, string mesa,
            string descricao, int estadoPedidoId,
            DateTime dataDoPedido
        ) {
            this.Id = id;
            this.Mesa = mesa;
            this.Descricao = descricao;
            this.EstadoPedidoId = estadoPedidoId;
            this.DataDoPedido = dataDoPedido;
        }
    }
}