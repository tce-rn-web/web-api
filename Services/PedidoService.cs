using System;
using System.Threading.Tasks;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services {
    public class PedidoService : IPedidoService {
        private readonly IPedidoRepository repository;

        public PedidoService(IPedidoRepository repository) {
            this.repository = repository;
        }

        public async Task<Pedido[]> ListarAsync(int idEstado) {
            // TODO: precisa validar os estado?
            // TODO: previnir SQL injection
            return await this.repository.ListarAsync(idEstado);
        }

        public async Task CadastrarAsync(Pedido pedido, Prato[] pratos) {
            
        }
    }
}