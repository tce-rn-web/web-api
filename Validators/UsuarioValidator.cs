using api.Exceptions;
using api.Models;
using api.Validators.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;


namespace api.Validators {
    public class UsuarioValidator : IUsuarioValidator {
        private void ValidarEmail(string email) {
            if(String.IsNullOrWhiteSpace(email)
                || !(new EmailAddressAttribute().IsValid(email))
            )
                throw new EmailInvalidoException();
        }

        private void ValidarSenha(string senha) {
            // TODO: Implementar critérios para uma senha melhor
            if(String.IsNullOrWhiteSpace(senha))
                throw new SenhaInvalidaException();
        }

        private void ValidarNome(string nome) {
            // TODO: Implementar critérios para um nome melhor
            if(String.IsNullOrWhiteSpace(nome))
                throw new NomeInvalidoException();
        }

        public void ValidarParaLogin(Usuario usuario) {
            this.ValidarEmail(usuario.Email);
            this.ValidarSenha(usuario.Senha);
        }

        public void ValidarParaCadastro(Usuario usuario) {
            this.ValidarEmail(usuario.Email);
            this.ValidarSenha(usuario.Senha);
            this.ValidarNome(usuario.Nome);
        }
    }
}