using System;

namespace api.Models.DTO {
    public class PedidoDTO {
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Descricao { get; set; }
        public int IdEstado { get; set; }
        public DateTime? DataDoPedido { get; set; }
        public Prato[] Pratos { get; set; }

        public PedidoDTO() {
            this.Id = 0;
            this.Mesa = "";
            this.Descricao = "";
            this.IdEstado = 0;
            this.DataDoPedido = null;
            this.Pratos = null;
        }

        public PedidoDTO(
            int id, string mesa,
            string descricao, int idEstado,
            DateTime dataDoPedido
        ) {
            this.Id = id;
            this.Mesa = mesa;
            this.Descricao = descricao;
            this.IdEstado = idEstado;
            this.DataDoPedido = dataDoPedido;
        }
    }
}