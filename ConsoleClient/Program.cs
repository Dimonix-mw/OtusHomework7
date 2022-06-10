using ConsoleClient.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleClient
{
    static class Program
    {

        static async Task Main(string[] args)
        {
            var provider = Configure();
            var consoleService = provider.GetService<IConsoleService>();
            await consoleService.Start();
        }

        private static IServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddHttpClient("http-api", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7124/");
            });
            services.AddScoped<IWebApiService, WebApiService>();
            services.AddScoped<IConsoleService, ConsoleService>();
            return services.BuildServiceProvider();

        }
    }
}