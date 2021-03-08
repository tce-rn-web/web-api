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
                    pp.PedidoId != pedido.Id ||
                    pp.PratoId <= 0 ||
                    pp.Quantidade <= 0
                )
                    throw new PedidoPratoInvalidoException();
            }
        }

        public void ValidarParaCadastro(Pedido pedido) {
            if(pedido == null)
                // TODO: Ver em que casos isso acontece
                throw new System.Exception();
            this.ValidarMesa(pedido);
            this.ValidarPedidosPratos(pedido);
        }

        // public void ValidarPratosDoPedido(Prato[] pratos) {
        //     foreach (Prato prato in pratos) {
        //         if(prato == null || prato.Id <= 0)
        //             // TODO: Criar uma nova exceção
        //             throw new System.Exception();
        //     }
        // }
    }
}