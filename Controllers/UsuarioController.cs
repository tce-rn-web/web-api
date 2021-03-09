using System.Threading.Tasks;
using api.Models;
using api.Models.DTO;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [Route("api")]
    public class UsuarioController : Controller {
        private readonly IUsuarioService service;

        public UsuarioController(IUsuarioService service) {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<TokenRespostaDTO> LoginAsync([FromBody] Usuario usuario) {
            return await this.service.LoginAsync(usuario);
        }

        [AllowAnonymous]
        [HttpPost("cadastro")]
        public async Task<TokenRespostaDTO> SignUp([FromBody] Usuario usuario) {
            // TODO: Por enquanto, só é permitido o cadastro de funcionarios
            usuario.CargoId = Cargo.FUNCIONARIO;
            await this.service.CadastrarAsync(usuario);
            return await this.service.LoginAsync(usuario);
        }

        [Authorize("Dono")]
        [HttpGet("usuario/listar")]
        public async Task<Usuario[]> ListarAsync() {
            return await this.service.ListarAsync();
        }

        [Authorize("Dono")]
        [HttpPut("usuario/{id}/editar")]
        public async Task EditarAsync(
            [FromRoute] int id,
            [FromBody] Usuario usuario
        ) {
            usuario.Id = id;
            await this.service.EditarAsync(usuario);
        }
    }
}