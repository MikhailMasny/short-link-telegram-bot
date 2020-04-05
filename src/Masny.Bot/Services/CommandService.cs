using Masny.Bot.Commands;
using Masny.Bot.Interfaces;
using System.Collections.Generic;

namespace Masny.Bot.Services
{
    public class CommandService : ICommandService
    {
        private readonly List<TelegramCommand> _commands;

        public CommandService()
        {
            _commands = new List<TelegramCommand>
            {
                new HelpCommand()
            };
        }

        public List<TelegramCommand> Get() => _commands;
    }
}
