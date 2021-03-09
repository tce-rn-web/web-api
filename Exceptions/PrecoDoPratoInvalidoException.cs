using System;

namespace api.Exceptions {
    public class PrecoDoPratoInvalidoException : Exception {
        public PrecoDoPratoInvalidoException() : base("O preço do prato precisa ser maior ou igual a zero.") {}
        public PrecoDoPratoInvalidoException(string message) : base(message) {}
    }
}