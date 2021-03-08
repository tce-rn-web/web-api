using api.Models;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces {
    public interface IUserRepository {
        Task Add(User user);
        Task<User> GetByEmail(string email);
    }
}