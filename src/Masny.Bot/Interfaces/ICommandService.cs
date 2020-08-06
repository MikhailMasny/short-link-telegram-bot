using System.Collections.Generic;

namespace Masny.Bot.Interfaces
{
    /// <summary>
    /// Commands management service.
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// Get all available commands.
        /// </summary>
        /// <returns>Command list.</returns>
        IEnumerable<ITelegramCommand> Get();
    }
}
