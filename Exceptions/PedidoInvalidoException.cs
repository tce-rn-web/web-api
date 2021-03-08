using System;

namespace api.Exceptions {
    public class PedidoInvalidoException : Exception {
        public PedidoInvalidoException() : base("O pedido informado é inválido.") {}
        public PedidoInvalidoException(string message) : base(message) {}
    }
}