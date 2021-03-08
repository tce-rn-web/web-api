using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using api.Configurarions;
using api.Models;
using api.Repositories.Interfaces;
using api.Service.Interfaces;
using api.Validators.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace api.Services {
    public class UserService : IUserService {
        private readonly IUserRepository repository;
        private readonly SigningConfiguration signingConfiguration;
        private readonly TokenConfiguration tokenConfiguration;
        private readonly IBaseValidator<User> validator;
        
        public UserService(
            IUserRepository repository,
            SigningConfiguration signingConfiguration,
            TokenConfiguration tokenConfiguration,
            IBaseValidator<User> validator
        ) {
            this.repository = repository;
            this.signingConfiguration = signingConfiguration;
            this.tokenConfiguration = tokenConfiguration;
            this.validator = validator;
        }

        public async Task<object> Login(User user) {
            User userDb = await this.repository.GetByEmail(user.Email);
            if(this.validator.isValid(user) && 
                userDb != null &&
                user.Email.Equals(userDb.Email) &&
                user.Password.Equals(userDb.Password)
            ) {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email, "Login"),
                    new [] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                    }
                );

                DateTime creationDate = DateTime.Now;
                DateTime expirationDate = creationDate +
                    TimeSpan.FromSeconds(tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
                    Issuer = tokenConfiguration.Issuer,
                    Audience = tokenConfiguration.Audience,
                    SigningCredentials = this.signingConfiguration.SigningCredentials,
                    Subject = identity,
                    NotBefore = creationDate,
                    Expires = expirationDate
                });

                var token = handler.WriteToken(securityToken);

                return new {
                    authenticated = true,
                    created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "Ok"
                };
            }
            return new {
                authenticated = false,
                message = "Usuário ou senha está incorreto."
            };
        }

        public async Task SignUp(User user) {
            if(!this.validator.isValid(user))
                // TODO: Fazer exceção customizada
                throw new Exception("Login ou senha inválidos");
            await repository.Add(user);
        }
    }
}