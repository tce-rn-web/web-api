using System;

namespace api.Exceptions {
    public class EmailJaEstaEmUsoException : Exception {
        public EmailJaEstaEmUsoException() : base("O e-mail informado já está em uso.") {}
        public EmailJaEstaEmUsoException(string message) : base(message) {}
    }
}