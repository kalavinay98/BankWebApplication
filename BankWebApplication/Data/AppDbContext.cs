using Microsoft.EntityFrameworkCore;

namespace BankWebApplication.Data
{
    public class AppDbContext : DbContext
    {
        // Configuration property
        private readonly IConfiguration _config;

        // Constructor with IConfiguration dependency injection
        public AppDbContext(IConfiguration config)
        {
            _config = config;
        }

        // Override OnConfiguring to use SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // Ensures options aren't configured twice
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
            }
        }

        // DbSets for Users, Accounts, and Transactions
        public DbSet<UsersTable> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
