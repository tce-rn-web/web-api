using System;
using System.Threading.Tasks;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using api.Validators.Interfaces;

namespace api.Services {
    public class PedidoService : IPedidoService {
        private readonly IPedidoRepository repository;
        private readonly IPedidoValidator validator;

        public PedidoService(
            IPedidoRepository repository,
            IPedidoValidator validator
        ) {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<Pedido[]> ListarAsync(int estadoPedidoId, bool incluirPratos) {
            return await this.repository.ListarAsync(estadoPedidoId, incluirPratos);
        }

        public async Task CadastrarAsync(Pedido pedido) {
            this.validator.ValidarParaCadastro(pedido);

            pedido.Id = 0;
            pedido.DataDoPedido = DateTime.Now;
            pedido.EstadoPedidoId = EstadoPedido.CADASTRADO;
            pedido.EstadoPedido = null;
            if(String.IsNullOrWhiteSpace(pedido.Descricao))
                pedido.Descricao = "";
            else
                pedido.Descricao = pedido.Descricao.Trim();
            foreach(PedidoPrato pp in pedido.PedidosPratos) {
                pp.Pedido = null;
                pp.Prato = null;
            }

            await repository.CadastrarAsync(pedido);
        }
    }
}