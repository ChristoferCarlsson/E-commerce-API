using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication5.DTO;
using WebApplication5.Interface;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class UserService : IUserService
    {
        private readonly EcommerceDbContext _context;

        public UserService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(UserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == userDto.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password, salt);

            var newUser = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = Encoding.UTF8.GetBytes(passwordHash),
                PasswordSalt = Encoding.UTF8.GetBytes(salt),
                Role = "user"
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<bool> IsUsernameExistAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }
    }
}
