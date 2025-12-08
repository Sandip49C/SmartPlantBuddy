using Final_Capstone_Project.Models;
using SmartPlantBuddy.Models;
using SQLite;

namespace SmartPlantBuddy.Data
{
    public class AppDbContext
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDbContext(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<User>().Wait();
            _db.CreateTableAsync<Sensor>().Wait();
            _db.CreateTableAsync<SensorReading>().Wait();
            _db.CreateTableAsync<Alert>().Wait();
            _db.CreateTableAsync<WateringLog>().Wait();

            SeedDataAsync().Wait();
        }

        private async Task SeedDataAsync()
        {
            if (await _db.Table<User>().CountAsync() == 0)
            {
                var hashed = BCrypt.Net.BCrypt.HashPassword("123456");
                await _db.InsertAsync(new User { Email = "test@plant.com", PasswordHash = hashed });

                var user = await _db.Table<User>().FirstAsync();
                await _db.InsertAsync(new Sensor { UserId = user.Id });
            }
        }

        public SQLiteAsyncConnection Database => _db;
    }
}