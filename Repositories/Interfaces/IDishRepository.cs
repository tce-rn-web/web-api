using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces {
    public interface IDishRepository {
        Task<Dish[]> GetDishs(bool outOfStock);
        Task<Dish> GetDishById(int id);
        Task<Dish> AddDish(Dish dish);
        Task<Dish> EditDish(Dish dish);
        Task<Dish> RemoveDish(Dish dish);
    }
}