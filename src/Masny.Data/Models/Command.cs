using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Masny.Data.Models
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, TelegramBotClient client);

        public abstract bool Contains(Message message);
    }
}
