using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories {
    public class UserRepository : IUserRepository {
        private readonly DatabaseContext context;

        public UserRepository(DatabaseContext context) {
            this.context = context;
        }
        
        public async Task Add(User user) {
            this.context.Add(user);

            if(await this.context.SaveChangesAsync() <= 0)
                throw new System.NotImplementedException();
        }

        public async Task<User> GetByEmail(string email) {
            IQueryable<User> query = this.context.Users;

            query = query.AsNoTracking()
                         .Where(user => user.Email == email);

            return await query.FirstOrDefaultAsync();
        }
    }
}