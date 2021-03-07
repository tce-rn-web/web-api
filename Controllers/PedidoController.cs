using System.Threading.Tasks;
using api.Models;
using api.Models.DTO;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller {
        private readonly IPedidoService service;

        public PedidoController(IPedidoService service) {
            this.service = service;
        }

        [HttpGet("listar")]
        public async Task<Pedido[]> ListarAsync(int idEstado = 0) {
            return await service.ListarAsync(idEstado);
        }

        [HttpPost("cadastrar")]
        public async Task CadastrarAsync(PedidoDTO pedidoDTO) {
            Pedido pedido = new Pedido(
                pedidoDTO.Id,
                pedidoDTO.Mesa,
                pedidoDTO.Descricao,
                pedidoDTO.IdEstado, // TODO: implementar estado
                null // A data é atribuída durante a inserção no banco de dados
            );

            Prato[] pratos = pedidoDTO.Pratos;

            // insere pedido
        }
    }
}