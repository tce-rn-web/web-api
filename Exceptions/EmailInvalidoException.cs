using System;

namespace api.Exceptions {
    public class EmailInvalidoException : Exception {
        public EmailInvalidoException() : base("O e-mail informado é inválido.") {}
        public EmailInvalidoException(string message) : base(message) {}
    }
}