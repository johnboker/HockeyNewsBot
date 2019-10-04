using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HockeyNewsBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var settings = configuration.GetSection("Settings").Get<Settings>();

            var bot = new Bot(settings);
            await bot.Start();

            await Task.Delay(-1);
        }
    }
}
