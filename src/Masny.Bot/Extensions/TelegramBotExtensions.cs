using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Masny.Bot.Extensions
{
    public static class TelegramBotExtensions
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var client = new TelegramBotClient(configuration["Token"]);
            var webHook = $"{configuration["Url"]}/api/message/update";
            client.SetWebhookAsync(webHook).Wait();

            serviceCollection.AddTransient<ITelegramBotClient>(x => client);

            return serviceCollection;
                
        }
    }
}
