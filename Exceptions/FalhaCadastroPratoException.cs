using System;

namespace api.Exceptions {
    public class FalhaCadastroPratoException : Exception {
        public FalhaCadastroPratoException() : base("Falha ao cadastrar prato.") {}
        public FalhaCadastroPratoException(string message) : base(message) {}
    }
}