using System.Threading.Tasks;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class PratoController : Controller {
        private readonly IPratoService service;

        public PratoController(IPratoService service) {
            this.service = service;
        }

        [Authorize("Autenticado")]
        [HttpGet("listar")]
        public async Task<Prato[]> ListarAsync() {
            return await this.service.ListarAsync();
        }

        [Authorize("Dono")]
        [HttpPost("cadastrar")]
        public async Task CadastrarAsync([FromBody] Prato prato) {
            await service.CadastrarAsync(prato);
        }

        [Authorize("Dono")]
        [HttpPut("{id}/editar")]
        public async Task EditarAsync(
            [FromRoute] int id,
            [FromBody] Prato prato
        ) {
            prato.Id = id;
            await service.EditarAsync(prato);
        }
    }
}