using System;

namespace api.Exceptions {
    public class UsuarioIdNaoCadastradoException : Exception {
        public UsuarioIdNaoCadastradoException() : base("O id do usuário informado não está cadastrado.") {}
        public UsuarioIdNaoCadastradoException(string message) : base(message) {}
    }
}