using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{
    public class SpecialtiesCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public SpecialtiesCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public string Name => "Програми на спеціальності Прикладна математика";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;

            await _botClient.SendTextMessageAsync(
            chatId,
            text: "Прикладна математика та інформатика, " +
                      "\nФінансовий інжинирінг ");
        }
    }
}
