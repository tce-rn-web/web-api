using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace api.Configurarions {
    public class SigningConfiguration {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfiguration() {
            using (var provider = new RSACryptoServiceProvider(2048)) {
                this.Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            this.SigningCredentials = new SigningCredentials(
                this.Key,
                SecurityAlgorithms.RsaSha256Signature
            );
        }
    }
}