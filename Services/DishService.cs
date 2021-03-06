using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace api.Services {
    public class DishService : IDishService {
        private readonly IDishRepository repository;

        public DishService(IDishRepository repository) {
            this.repository = repository;
        }

        public async Task<Dish[]> GetDishs(bool outOfStock) {
            return await repository.GetDishs(outOfStock);
        }

        public async Task<Dish> GetDishById(int id) {
            return await repository.GetDishById(id);
        }

        public async Task<Dish> AddDish(Dish dish) {
            return await repository.AddDish(dish);
        }

        public async Task<Dish> EditDish(Dish dish) {
            return await repository.EditDish(dish);
        }

        public async Task<Dish> RemoveDishById(int id) {
            Dish dish = await repository.GetDishById(id);
            
            if(dish.Id > 0)
                return await repository.RemoveDish(dish);
            throw new Exception("Error 500: Internal Server Error!");
        }
    }
}