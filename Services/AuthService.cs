using SmartPlantBuddy.Data;
using SmartPlantBuddy.Models;

namespace SmartPlantBuddy.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<bool> IsLoggedInAsync();
    }

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;

        public AuthService(AppDbContext db) => _db = db;

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _db.Database.Table<User>().FirstOrDefaultAsync(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                await SecureStorage.SetAsync("isLoggedIn", "true");
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            SecureStorage.Remove("isLoggedIn");
        }

        public async Task<bool> IsLoggedInAsync()
        {
            var value = SecureStorage.GetAsync("isLoggedIn").Result;
            return value == "true";
        }
    }
}