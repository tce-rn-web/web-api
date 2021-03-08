using System;
using System.Threading.Tasks;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [Route("api/[controller]")]
    public class AuthController : Controller {
        private readonly IUserService service;

        public AuthController(IUserService service) {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<object> Login([FromBody] User user) {
            return await this.service.Login(user);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<object> SignUp([FromBody] User user) {
            await this.service.SignUp(user);
            return await this.service.Login(user);
        }
    }
}