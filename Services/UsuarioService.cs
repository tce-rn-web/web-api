using api.Configurarions;
using api.Exceptions;
using api.Models;
using api.Models.DTO;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using api.Validators.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace api.Services {
    public class UsuarioService : IUsuarioService {
        private readonly IUsuarioRepository repository;
        private readonly SigningConfiguration signingConfiguration;
        private readonly TokenConfiguration tokenConfiguration;
        private readonly IUsuarioValidator validator;
        
        public UsuarioService(
            IUsuarioRepository repository,
            SigningConfiguration signingConfiguration,
            TokenConfiguration tokenConfiguration,
            IUsuarioValidator validator
        ) {
            this.repository = repository;
            this.signingConfiguration = signingConfiguration;
            this.tokenConfiguration = tokenConfiguration;
            this.validator = validator;
        }

        public async Task<TokenRespostaDTO> LoginAsync(Usuario usuario) {
            this.validator.ValidarParaLogin(usuario);
            Usuario usuarioDb = await this.repository.EncontrarPorEmailAsync(usuario.Email);
            
            if(usuarioDb != null &&
                usuario.Email.Equals(usuarioDb.Email) &&
                usuario.Senha.Equals(usuario.Senha)
            ) {
                ClaimsIdentity identidade = new ClaimsIdentity(
                    new GenericIdentity(usuario.Email, "Login"),
                    new [] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email)
                    }
                );

                DateTime dataDeCriacao = DateTime.Now;
                DateTime dataDeValidade = dataDeCriacao +
                    TimeSpan.FromSeconds(tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
                    Issuer = tokenConfiguration.Issuer,
                    Audience = tokenConfiguration.Audience,
                    SigningCredentials = this.signingConfiguration.SigningCredentials,
                    Subject = identidade,
                    NotBefore = dataDeCriacao,
                    Expires = dataDeValidade
                });

                var token = handler.WriteToken(securityToken);

                return TokenRespostaDTO.CriarTokenDeSucesso(
                    dataDeCriacao,
                    dataDeValidade,
                    token
                );
            }
            return TokenRespostaDTO.CriarTokenDeFalha("Usuário ou senha inválido.");
        }

        public async Task CadastrarAsync(Usuario usuario) {
            this.validator.ValidarParaCadastro(usuario);

            var usuarioDb = await this.repository.EncontrarPorEmailAsync(usuario.Email);
            if(usuarioDb == null || usuarioDb.Id == 0) {
                usuario.Id = 0; // Garantia de que o banco de dados irá criar um novo usuário
                await repository.CadastrarAsync(usuario);
            }
            else
                throw new EmailJaEstaEmUsoException();
        }
    }
}