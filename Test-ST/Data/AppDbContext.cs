using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Test_ST.Models;

namespace Test_ST.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Form> Forms { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
