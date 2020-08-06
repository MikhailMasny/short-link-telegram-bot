using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Masny.Bot.Interfaces
{
    /// <summary>
    /// Telegram command.
    /// </summary>
    public interface ITelegramCommand
    {
        /// <summary>
        /// Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="client">TelegramBot client interface.</param>
        Task Execute(Message message, ITelegramBotClient client);

        /// <summary>
        /// Find a command.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>Operation result.</returns>
        bool Contains(Message message);
    }
}
