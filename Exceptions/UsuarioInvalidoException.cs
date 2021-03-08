using System;

namespace api.Exceptions {
    public class UsuarioInvalidoException : Exception {
        public UsuarioInvalidoException() : base("O usuário informado é inválido.") {}
        public UsuarioInvalidoException(string message) : base(message) {}
    }
}