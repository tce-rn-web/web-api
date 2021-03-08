using System;

namespace api.Exceptions {
    public class PedidoPratoInvalidoException : Exception {
        public PedidoPratoInvalidoException() : base("Um dos pratos informados no pedido é inválido.") {}
        public PedidoPratoInvalidoException(string message) : base(message) {}
    }
}