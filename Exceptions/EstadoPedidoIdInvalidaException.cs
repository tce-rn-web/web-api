using System;

namespace api.Exceptions {
    public class EstadoPedidoIdInvalidaException : Exception {
        public EstadoPedidoIdInvalidaException() : base("O id do estado do pedido informado é inválido.") {}
        public EstadoPedidoIdInvalidaException(string message) : base(message) {}
    }
}