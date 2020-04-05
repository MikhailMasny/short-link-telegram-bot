using Masny.Bot.Interfaces;
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
        public BotController(ICommandService commandService, ITelegramBotClient telegramBotClient)
        {
            _commandService = commandService;
            _telegramBotClient = telegramBotClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Started");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var message = update.Message;
            Console.WriteLine(message.Text);

            var chatId = message.Chat.Id;
            await _telegramBotClient.SendTextMessageAsync(chatId, "\U0001F4D6 Помощь");

            //foreach (var command in _commandService.Get())
            //{
            //    Console.WriteLine(message.Type);

            //    if (command.Contains(message))
            //    {
            //        await command.Execute(message, _telegramBotClient);
            //        break;
            //    }
            //}

            return Ok();
        }
    }
}
