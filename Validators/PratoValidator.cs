using System;
using api.Models;
using api.Validators.Interfaces;
using api.Exceptions;

namespace api.Validators {
    public class PratoValidator : IPratoValidator {
        private void ValidarId(Pedido pedido) {
            if(pedido.Id <= 0)
                throw new PedidoIdInvalidoException();
        }

        private void ValidarNome(Prato prato) {
            if(String.IsNullOrWhiteSpace(prato.Nome))
                throw new NomeDoPratoInvalidoException();
        }

        private void ValidarPreco(Prato prato) {
            if(prato.Preco < 0.0f)
                throw new PrecoDoPratoInvalidoException();
        }

        public void Validar(Prato prato) {
            if(prato == null)
                throw new PratoInvalidoException();
            this.ValidarNome(prato);
            this.ValidarPreco(prato);
        }
    }
}