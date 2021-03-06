using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories {
    public class DishRepository : IDishRepository {
        private readonly DatabaseContext context;

        public DishRepository(DatabaseContext context) {
            this.context = context;
        }
        public async Task<Dish[]> GetDishs(bool outOfStock) {
            IQueryable<Dish> query = this.context.Dishes;

            if(!outOfStock)
                query = query.AsNoTracking()
                    .OrderBy(dish => dish.Id)
                    .Where(dish => dish.InStock);
            else
                query = query.AsNoTracking()
                    .OrderBy(dish => dish.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Dish> GetDishById(int id) {
            IQueryable<Dish> query = this.context.Dishes;

            query = query.AsNoTracking()
                .OrderBy(dish => dish.Id)
                .Where(dish => dish.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Dish> AddDish(Dish dish) {
            this.context.Add(dish);

            if(await this.context.SaveChangesAsync() > 0)
                return dish;

            // TODO: Create Exceptions after
            throw new Exception("Error 500: Internal Server Error!");
        }

        public async Task<Dish> EditDish(Dish dish) {
            this.context.Update(dish);

            if(await this.context.SaveChangesAsync() > 0)
                return dish;
            // TODO: Create Exceptions after
            throw new Exception("Error 500: Internal Server Error!");
        }

        public async Task<Dish> RemoveDish(Dish dish) {
            this.context.Remove(dish);

            if(await this.context.SaveChangesAsync() > 0)
                return dish;
            // TODO: Create Exceptions after
            throw new Exception("Error 500: Internal Server Error!");
        }
    }
}