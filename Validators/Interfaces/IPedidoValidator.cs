using api.Models;

namespace api.Validators.Interfaces {
    public interface IPedidoValidator {
        void ValidarPedido(Pedido pedido);
        void ValidarPratosDoPedido(Prato[] pratos);
    }
}