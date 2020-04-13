using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Masny.Bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class LinkCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = "/link";

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var text = string.Empty;

            try
            {
                var link = await @is.gd.Url.GetShortenedUrl(message.Text);
                text = $"\U0001F525 Keep a simplified link: {link}";
            }
            catch (Exception ex)
            {
                text = "Hmm.. This is not a link, try sending something else! \U0001F4A9";
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await client.SendTextMessageAsync(message.Chat.Id, text);
            }
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : true;
    }
}
