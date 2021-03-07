using api.Models;
using api.Validators.Interfaces;

namespace api.Validators {
    public class PedidoValidator : IPedidoValidator {
        public void ValidarPedido(Pedido pedido) {
            if(pedido == null 
                || pedido.Id <= 0
                // TODO: terminar os campos
            )
                // TODO: Criar uma nova exceção
                throw new System.Exception();
        }

        public void ValidarPratosDoPedido(Prato[] pratos) {
            foreach (Prato prato in pratos) {
                if(prato == null || prato.Id <= 0)
                    // TODO: Criar uma nova exceção
                    throw new System.Exception();
            }
        }
    }
}