using System;

namespace api.Exceptions {
    public class PratoIdNaoCadastradoException : Exception {
        public PratoIdNaoCadastradoException() : base("O id do prato informado não está cadastrado.") {}
        public PratoIdNaoCadastradoException(string message) : base(message) {}
    }
}