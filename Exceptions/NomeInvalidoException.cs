using System;

namespace api.Exceptions {
    public class NomeInvalidoException : Exception {
        public NomeInvalidoException() : base("O nome informado é inválido.") {}
        public NomeInvalidoException(string message) : base(message) {}
    }
}