using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{
    public class OfficialSiteCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public OfficialSiteCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public string Name => "Офіційний сайт";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;


            await _botClient.SendTextMessageAsync(chatId, "https://amath.lp.edu.ua/");

        }
    }
}
