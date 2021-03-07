using System;

namespace api.Models.DTO {
    public class TokenRespostaDTO {
        public bool Autenticado { get; set; }
        public string DataDeCriacao { get; set; }
        public string DataDeValidade { get; set; }
        public string Token { get; set; }
        public string Mensagem { get; set; }

        public TokenRespostaDTO() {
            this.Autenticado = false;
            this.DataDeCriacao = null;
            this.DataDeValidade = null;
            this.Token = null;
            this.Mensagem = "Ocorreu um erro.";
        }
        public TokenRespostaDTO(
            bool autenticado,
            string dataDeCriacao,
            string dataDeValidade,
            string token,
            string mensagem
        ) {
            this.Autenticado = autenticado;
            this.DataDeCriacao = dataDeCriacao;
            this.DataDeValidade = dataDeValidade;
            this.Token = token;
            this.Mensagem = mensagem;
        }

        public static TokenRespostaDTO CriarTokenDeSucesso(
            DateTime dataDeCriacao,
            DateTime dataDeValidade,
            string token
        ) {
            return new TokenRespostaDTO(
                true,
                dataDeCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                dataDeValidade.ToString("yyyy-MM-dd HH:mm:ss"),
                token,
                "Ok"
            );
        }
        public static TokenRespostaDTO CriarTokenDeFalha(string mensagem) {
            return new TokenRespostaDTO(
                false, null,
                null, null,
                mensagem
            );
        }
    }
}