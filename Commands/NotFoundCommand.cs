using Telegram.Bot;
using Telegram.Bot.Types;

namespace lab_4.Controllers.Commands
{
    public class NotFoundCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public NotFoundCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public string Name => "notfound";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            string text = "Не знаю такої команди";

            await _botClient.SendTextMessageAsync(chatId, text);
        }
    }
}
