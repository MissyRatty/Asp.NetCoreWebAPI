using CustomerAccountServer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAccountServer.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
