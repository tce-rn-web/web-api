using api.Models;
using System.Threading.Tasks;

namespace api.Service.Interfaces {
    public interface IUserService {
        Task SignUp(User user);

        Task<object> Login(User user);
    }
}