using api.Models;

namespace api.Validators.Interfaces {
    public interface IPedidoValidator {
        void ValidarParaCadastro(Pedido pedido);
        void ValidarParaEdicao(Pedido pedido);
    }
}