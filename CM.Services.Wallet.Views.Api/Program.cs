using CM.Services.Wallet.Views.Infrastracture.Contexts;
using CM.Shared.Web.Others.Kong;
using CM.Shared.Web.Others.Postgres;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CM.Services.Wallet.Views.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                .RegisterKong()
                .RegisterPostgres<ApplicationContext>(async (context, services) => await context.Seed())
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
