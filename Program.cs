using Betty.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Betty
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            var serviceProvider = Startup.ConfigureServices();
            var gameEngine = serviceProvider.GetEngine();
            gameEngine.RunEngine();
        }
    }
}
