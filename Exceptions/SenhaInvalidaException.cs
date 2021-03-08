using System;

namespace api.Exceptions {
    public class SenhaInvalidaException : Exception {
        public SenhaInvalidaException() : base("A senha informada é inválida.") {}
        public SenhaInvalidaException(string message) : base(message) {}
    }
}