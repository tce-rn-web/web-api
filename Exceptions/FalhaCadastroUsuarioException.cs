using System;

namespace api.Exceptions {
    public class FalhaCadastroUsuarioException : Exception {
        public FalhaCadastroUsuarioException() : base("Falha ao cadastrar usuário.") {}
        public FalhaCadastroUsuarioException(string message) : base(message) {}
    }
}