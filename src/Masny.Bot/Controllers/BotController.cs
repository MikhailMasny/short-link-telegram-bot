using Masny.Bot.Interfaces;
using Masny.Bot.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Masny.Bot.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class BotController : ControllerBase
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ICommandService _commandService;

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="commandService">Interface to use the command service.</param>
        /// <param name="telegramBotClient">Interface to use the Telegram Bot API.</param>
        public BotController(
            ICommandService commandService,
            ITelegramBotClient telegramBotClient)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _telegramBotClient = telegramBotClient ?? throw new ArgumentNullException(nameof(telegramBotClient));
        }

        /// <summary>
        /// Request processing method.
        /// </summary>
        /// <param name="update">Incoming update.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null)
            {
                return NoContent();
            }

            var message = update.Message;

            // (!) NOTICE: Use this code only for debug
            Console.WriteLine(
                string.Format(
                    Common.Message,
                    message.Chat.Id,
                    message.Text));

            foreach (var command in _commandService.Get())
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, _telegramBotClient);
                    break;
                }
            }

            return Ok();
        }
    }
}
