using System.Threading.Tasks;
using api.Models;
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
            return await this.service.ListarAsync(estadoPedidoId, incluirPratos);
        }

        [HttpGet("{id}")]
        public async Task<Pedido> EncontrarPorIdAsync(
            [FromRoute] int id,
            [FromQuery] bool includePratos = false
        ) {
            return await this.service.EncontrarPorIdAsync(id, includePratos);
        }

        [HttpPost("cadastrar")]
        public async Task CadastrarAsync([FromBody] Pedido pedido) {
            await this.service.CadastrarAsync(pedido);
        }

        [HttpPut("{id}/editar")]
        public async Task EditarAsync(
            [FromRoute] int id, 
            [FromBody] Pedido pedido
        ) {
            pedido.Id = id;
            await this.service.EditarAsync(pedido);
        }

        [HttpPut("{id}/cadastrado")]
        public async Task CadastradoAsync([FromRoute] int id) {
            await this.service.AlterarEstadoPedidoAsync(id, EstadoPedido.CADASTRADO);
        }

        [HttpPut("{id}/cancelado")]
        public async Task CanceladoAsync([FromRoute] int id) {
            await this.service.AlterarEstadoPedidoAsync(id, EstadoPedido.CANCELADO);
        }

        [HttpPut("{id}/preparando")]
        public async Task PreparandoAsync([FromRoute] int id) {
            await this.service.AlterarEstadoPedidoAsync(id, EstadoPedido.PREPARANDO);
        }

        [HttpPut("{id}/preparado")]
        public async Task PreparadoAsync([FromRoute] int id) {
            await this.service.AlterarEstadoPedidoAsync(id, EstadoPedido.PREPARADO);
        }

        [HttpPut("{id}/entregando")]
        public async Task EntregandoAsync([FromRoute] int id) {
            await this.service.AlterarEstadoPedidoAsync(id, EstadoPedido.ENTREGANDO);
        }

        [HttpPut("{id}/entregue")]
        public async Task EntregueAsync(int id) {
            await this.service.AlterarEstadoPedidoAsync(id, EstadoPedido.ENTREGUE);
        }

        [HttpPut("{id}/finalizado")]
        public async Task FinalizadoAsync([FromRoute] int id) {
            await this.service.AlterarEstadoPedidoAsync(id, EstadoPedido.FINALIZADO);
        }
    }
}