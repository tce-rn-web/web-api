using System;

namespace api.Exceptions {
    public class MesaDoPedidoInvalidaException : Exception {
        public MesaDoPedidoInvalidaException() : base("A mesa informada é inválida.") {}
        public MesaDoPedidoInvalidaException(string message) : base(message) {}
    }
}