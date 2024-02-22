using Microsoft.EntityFrameworkCore;
using testApp.Models;

namespace testApp.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options): base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; } 
    }
}
