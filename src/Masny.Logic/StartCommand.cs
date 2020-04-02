using Masny.Logic.Interfaces;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Masny.Logic
{
    public class StartCommand : ICommand
    {
        public string Name => @"/start";

        public bool Contains(Message message)
        {
            return message.Type != Telegram.Bot.Types.Enums.MessageType.Text ? false : message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, "Hallo I'm ASP.NET Core Bot", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
