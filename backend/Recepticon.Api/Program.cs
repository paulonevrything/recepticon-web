using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Recepticon.Api.Extensions;
using Recepticon.Persistence;

namespace Recepticon.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase<RecepticonDbContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
