using System;
using api.Models;
using api.Validators.Interfaces;
using api.Exceptions;

namespace api.Validators {
    public class PedidoValidator : IPedidoValidator {
        private void ValidarId(Pedido pedido) {
            if(pedido.Id <= 0)
                throw new PedidoIdInvalidoException();
        }

        private void ValidarMesa(Pedido pedido) {
            if(String.IsNullOrWhiteSpace(pedido.Mesa))
                throw new MesaDoPedidoInvalidaException();
        }
        private void ValidarEstadoPedidoId(Pedido pedido) {
            if(pedido.EstadoPedidoId != EstadoPedido.CADASTRADO &&
                pedido.EstadoPedidoId != EstadoPedido.CANCELADO &&
                pedido.EstadoPedidoId != EstadoPedido.PREPARANDO &&
                pedido.EstadoPedidoId != EstadoPedido.PREPARADO &&
                pedido.EstadoPedidoId != EstadoPedido.ENTREGANDO &&
                pedido.EstadoPedidoId != EstadoPedido.ENTREGUE &&
                pedido.EstadoPedidoId != EstadoPedido.FINALIZADO
            )
                throw new EstadoPedidoIdInvalidaException();
        }

        private void ValidarPedidosPratos(Pedido pedido) {
            if(pedido.PedidosPratos == null || 
                pedido.PedidosPratos.Count == 0
            )
                throw new PedidoSemPratosException();
            
            foreach(PedidoPrato pp in pedido.PedidosPratos) {
                if(pp == null || 
                    pp.PratoId <= 0 ||
                    pp.Quantidade <= 0
                )
                    throw new PedidoPratoInvalidoException();
            }
        }

        public void ValidarParaCadastro(Pedido pedido) {
            if(pedido == null)
                throw new PedidoInvalidoException();
            this.ValidarMesa(pedido);
            this.ValidarPedidosPratos(pedido);
        }
        public void ValidarParaEdicao(Pedido pedido) {
            if(pedido == null)
                throw new PedidoInvalidoException();
            this.ValidarId(pedido);
            this.ValidarMesa(pedido);
            this.ValidarEstadoPedidoId(pedido);
            this.ValidarPedidosPratos(pedido);
        }
    }
}