using WebApplication5.DTO;
using WebApplication5.Models;

namespace WebApplication5.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(UserDto userDto);
        Task<bool> IsUsernameExistAsync(string username);
    }
}
