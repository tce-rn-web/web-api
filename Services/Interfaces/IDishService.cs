using System.Threading.Tasks;
using api.Models;

namespace api.Services.Interfaces {
    public interface IDishService {
        Task<Dish[]> GetDishs(bool outOfStock);
        Task<Dish> GetDishById(int id);
        Task<Dish> AddDish(Dish dish);
        Task<Dish> EditDish(Dish dish);
        Task<Dish> RemoveDishById(int id);
    }
}