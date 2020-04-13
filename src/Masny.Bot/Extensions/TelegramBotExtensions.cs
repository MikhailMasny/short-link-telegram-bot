using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Masny.Bot.Extensions
{
    /// <summary>
    /// TelegramBot extension method.
    /// </summary>
    public static class TelegramBotExtensions
    {
        /// <summary>
        /// Add TelegramBot client.
        /// </summary>
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
