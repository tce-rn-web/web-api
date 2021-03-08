using System;

namespace api.Models.DTO {
    public class TokenRespostaDTO {
        public bool Autenticado { get; set; }
        public string DataDeCriacao { get; set; }
        public string DataDeValidade { get; set; }
        public string Token { get; set; }
        public string Mensagem { get; set; }
        public int CargoId { get; set; }

        public TokenRespostaDTO() {
            this.Autenticado = false;
            this.DataDeCriacao = null;
            this.DataDeValidade = null;
            this.Token = null;
            this.Mensagem = "Ocorreu um erro.";
            this.CargoId = 0;
        }
        public TokenRespostaDTO(
            bool autenticado,
            string dataDeCriacao,
            string dataDeValidade,
            string token,
            string mensagem,
            int cargoId
        ) {
            this.Autenticado = autenticado;
            this.DataDeCriacao = dataDeCriacao;
            this.DataDeValidade = dataDeValidade;
            this.Token = token;
            this.Mensagem = mensagem;
            this.CargoId = cargoId;
        }

        public static TokenRespostaDTO CriarTokenDeSucesso(
            DateTime dataDeCriacao,
            DateTime dataDeValidade,
            string token,
            int cargoId
        ) {
            return new TokenRespostaDTO(
                true,
                dataDeCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                dataDeValidade.ToString("yyyy-MM-dd HH:mm:ss"),
                token,
                "Ok",
                cargoId
            );
        }
        public static TokenRespostaDTO CriarTokenDeFalha(string mensagem) {
            return new TokenRespostaDTO(
                false, null,
                null, null,
                mensagem,
                0
            );
        }
    }
}