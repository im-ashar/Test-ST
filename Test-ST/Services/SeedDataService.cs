using Microsoft.EntityFrameworkCore;
using Test_ST.Data;
namespace Test_ST.Services
{
    public interface ISeedDataService
    {
        Task SeedDataAsync();
    }
    public class SeedDataService : ISeedDataService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public SeedDataService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task SeedDataAsync()
        {
            await MigrateDatabase();
        }

        private async Task MigrateDatabase()
        {
            using var context = _contextFactory.CreateDbContext();
            await context.Database.MigrateAsync();
        }
    }
}
