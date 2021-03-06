using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data {
    public class DatabaseContext : DbContext {

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Dish>();
            builder.Entity<User>(user => {
                user.HasKey(u => u.Id);
                user.HasIndex(u => u.Email).IsUnique();
            });
            
                
                
            // builder.Entity<Dish>()
            //     .HasData(new Dish[] {
            //         new Dish(1, 149.90f, "Ventilador De Mesa Maxi Power 40 Cm V-40-w Mondial", true),
            //         new Dish(2, 160.09f, "Relógio Smartwatch Xiaomi Haylou Ls02 Versão Global", true),
            //         new Dish(3, 1299.00f, "LG K61 Dual SIM 128 GB titânio 4 GB RAM", false)
            //     });
            
        }
    }
}