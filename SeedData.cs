using Bogus;
using System.Security.Cryptography;
using System.Text;
using WebApplication5.Models;

public static class SeedData
{
    public static void Initialize(EcommerceDbContext context)
    {
        // Check if the database is already populated
        if (!context.Users.Any())
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Role, f => f.PickRandom("Admin", "User")); // Random role

            var users = userFaker.Generate(10); // Generate 10 users

            foreach (var user in users)
            {
                // Hash the password for each user
                string password = "Password123"; // Default password for example
                var passwordHashSalt = HashPassword(password);
                user.PasswordHash = passwordHashSalt.Item1;
                user.PasswordSalt = passwordHashSalt.Item2;

                // Add user to the database
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }

    // Simple password hashing method
    private static Tuple<byte[], byte[]> HashPassword(string password)
    {
        using (var hmac = new HMACSHA256())
        {
            var passwordSalt = hmac.Key; // Generate a salt using HMACSHA256
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Hash the password

            return new Tuple<byte[], byte[]>(passwordHash, passwordSalt);
        }
    }
}
