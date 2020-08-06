using Masny.Bot.Interfaces;
using Masny.Bot.Resources;
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
        public string Name { get; } = Link.Text;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var text = string.Empty;

            try
            {
                var link = await @is.gd.Url.GetShortenedUrl(message.Text);
                text = string.Format($"\U0001F525 {Link.Message}", link);
            }
            catch (Exception ex)
            {
                text = $"{Link.Exception} \U0001F4A9";
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await client.SendTextMessageAsync(message.Chat.Id, text);
            }
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type == MessageType.Text;
    }
}
