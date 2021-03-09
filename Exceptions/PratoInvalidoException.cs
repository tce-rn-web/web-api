using System;

namespace api.Exceptions {
    public class PratoInvalidoException : Exception {
        public PratoInvalidoException() : base("O prato informado é inválido.") {}
        public PratoInvalidoException(string message) : base(message) {}
    }
}