using Masny.Bot.Commands;
using System.Collections.Generic;

namespace Masny.Bot.Interfaces
{
    /// <summary>
    /// Commands management service.
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TelegramCommand> Get();
    }
}
