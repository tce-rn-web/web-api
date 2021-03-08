using System;

namespace api.Exceptions {
    public class CargoIdInvalidoException : Exception {
        public CargoIdInvalidoException() : base("O id do cargo do usuário informado é inválido.") {}
        public CargoIdInvalidoException(string message) : base(message) {}
    }
}