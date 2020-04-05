using Masny.Bot.Commands;
using System.Collections.Generic;

namespace Masny.Bot.Interfaces
{
    public interface ICommandService
    {
        List<TelegramCommand> Get();
    }
}
