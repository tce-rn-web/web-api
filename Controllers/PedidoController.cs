using System.Threading.Tasks;
using api.Models;
using api.Models.DTO;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize("Funcionário")]
    [Route("api/[controller]")]
    public class PedidoController : Controller {
        private readonly IPedidoService service;

        public PedidoController(IPedidoService service) {
            this.service = service;
        }

        [HttpGet("listar")]
        public async Task<Pedido[]> ListarAsync(
            [FromQuery] int estadoPedidoId = 0, 
            [FromQuery] bool incluirPratos = false
        ) {
            return await service.ListarAsync(estadoPedidoId, incluirPratos);
        }

        [HttpPost("cadastrar")]
        public async Task CadastrarAsync([FromBody] Pedido pedido) {
            await service.CadastrarAsync(pedido);
        }
    }
}