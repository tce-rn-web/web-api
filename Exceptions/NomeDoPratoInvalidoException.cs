using System;

namespace api.Exceptions {
    public class NomeDoPratoInvalidoException : Exception {
        public NomeDoPratoInvalidoException() : base("O nome do prato informado é inválido.") {}
        public NomeDoPratoInvalidoException(string message) : base(message) {}
    }
}