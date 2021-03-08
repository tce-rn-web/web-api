using System;

namespace api.Exceptions {
    public class PedidoIdNaoCadastradoException : Exception {
        public PedidoIdNaoCadastradoException() : base("O id do pedido informado não está cadastrado.") {}
        public PedidoIdNaoCadastradoException(string message) : base(message) {}
    }
}