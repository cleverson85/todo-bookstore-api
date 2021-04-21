using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ToDo.Infrastructure.Data.Contexts;
using ToDo.Infrastructure.IoC;

namespace ToDo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDbContext<Context>()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
