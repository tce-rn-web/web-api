using System;

namespace api.Exceptions {
    public class FalhaCadastroPedidoException : Exception {
        public FalhaCadastroPedidoException() : base("Falha ao cadastrar pedido.") {}
        public FalhaCadastroPedidoException(string message) : base(message) {}
    }
}