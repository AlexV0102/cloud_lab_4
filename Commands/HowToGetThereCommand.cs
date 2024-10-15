using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{
    public class HowToGetThereCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public HowToGetThereCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public string Name => "Як добратися";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;

            await _botClient.SendTextMessageAsync(
                chatId,
                text: "79013, Львів 13, вул. Митрополита Андрея 5, IV навчальний корпус, кімната 213");
        }
    }
}
