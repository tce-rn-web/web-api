using System;

namespace api.Exceptions {
    public class PedidoIdInvalidoException : Exception {
        public PedidoIdInvalidoException() : base("O id do pedido informado é inválido.") {}
        public PedidoIdInvalidoException(string message) : base(message) {}
    }
}