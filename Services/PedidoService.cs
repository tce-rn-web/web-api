using System;
using System.Threading.Tasks;
using api.Exceptions;
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
        public async Task<Pedido> EncontrarPorIdAsync(int id, bool incluirPratos) {
            if(id <= 0)
                throw new PedidoIdInvalidoException();
            return await this.repository.EncontrarPorIdAsync(id, incluirPratos);
        }
        public async Task CadastrarAsync(Pedido pedido) {
            pedido.Id = 0;
            this.validator.ValidarParaCadastro(pedido);

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
        public async Task EditarAsync(Pedido pedido) {
            this.validator.ValidarParaEdicao(pedido);

            pedido.DataDoPedido = null;
            pedido.EstadoPedido = null;
            if(String.IsNullOrWhiteSpace(pedido.Descricao))
                pedido.Descricao = "";
            else
                pedido.Descricao = pedido.Descricao.Trim();
            foreach(PedidoPrato pp in pedido.PedidosPratos) {
                pp.PedidoId = pedido.Id;
                pp.Pedido = null;
                pp.Prato = null;
            }

            await repository.EditarAsync(pedido);   
        }

        public async Task AlterarEstadoPedidoAsync(int id, int estadoPedidoId) {
            if(id <= 0)
                throw new PedidoIdInvalidoException();
            if(estadoPedidoId != EstadoPedido.CADASTRADO &&
                estadoPedidoId != EstadoPedido.CANCELADO &&
                estadoPedidoId != EstadoPedido.PREPARANDO &&
                estadoPedidoId != EstadoPedido.PREPARADO &&
                estadoPedidoId != EstadoPedido.ENTREGANDO &&
                estadoPedidoId != EstadoPedido.ENTREGUE &&
                estadoPedidoId != EstadoPedido.FINALIZADO
            )
                throw new EstadoPedidoIdInvalidaException();

            await repository.AlterarEstadoPedidoAsync(id, estadoPedidoId);
        }
    }
}