using System;

namespace api.Exceptions {
    public class PedidoSemPratosException : Exception {
        public PedidoSemPratosException() : base("O pedido informado não possui pratos.") {}
        public PedidoSemPratosException(string message) : base(message) {}
    }
}