using CM.Services.Wallet.Views.Contract.Domain.Models;
using CM.Services.Wallet.Views.Infrastracture.Constants;
using CM.Services.Wallet.Views.Infrastracture.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.Infrastracture.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaNames.Default);

            // Domain
            new UserMap(modelBuilder.Entity<User>());
        }
    }

    public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql("Server=tcp:127.0.0.1,5433;Database=CM_Services_WalletViewsDb;User Id=SA;Password=Test1990!;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }

    public static class ApplicationContextExtensions
    {
        public static async Task Seed(this ApplicationContext context)
        {
            await Task.CompletedTask;
        }
    }
}