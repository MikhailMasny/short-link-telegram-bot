using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Masny.Bot.Commands
{
    public abstract class TelegramCommand
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, ITelegramBotClient client);

        public abstract bool Contains(Message message);
    }
}
