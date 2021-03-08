using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase {
        private readonly IDishService service;

        public DishController(IDishService service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDishs(bool outOfStock = false) {
            try {
                var result = await service.GetDishs(outOfStock);
                return Ok(result);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishById(int id) {
            try {
                var result = await service.GetDishById(id);
                return Ok(result);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDish(Dish dish) {
            try {
                var result = await service.AddDish(dish);
                return Ok(result);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditDish(Dish dish) {
            try {
                var result = await service.EditDish(dish);
                return Ok(result);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDishById(int id) {
            try {
                var result = await service.RemoveDishById(id);
                return Ok(result);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}