using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace lab_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private readonly UpdateDistributor<CommandExecutor> updateDistributor = new();

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update.Message == null)
            {
                return Ok();
            }

            await updateDistributor.GetUpdate(update);

            return Ok();
        }
        [HttpGet]
        public string Get()
        {
            return "Telegram bot is running";
        }
    }
}
