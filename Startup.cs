using Betty.Services;
using Betty.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Betty
{
    public static class Startup
    {
        public static IServiceProvider ConfigureServices()
            => new ServiceCollection()
                .AddSingleton<IBalanceSerivce, BalanceService>()
                .AddSingleton<IBettingService, BettingService>()
                .AddSingleton<ICommandService, CommandService>()
                .AddSingleton<IEngineService, BettyEngineService>()
                .AddSingleton<IClient, ConsoleClient>()
                .BuildServiceProvider();

        public static IEngineService GetEngine(this IServiceProvider services)
            => services.GetRequiredService<IEngineService>();
    }
}