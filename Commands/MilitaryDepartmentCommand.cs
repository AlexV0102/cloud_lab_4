using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{

    public class MilitaryDepartmentCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public MilitaryDepartmentCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public string Name => "Військова кафедра";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;


            await _botClient.SendTextMessageAsync(
                chatId,
                text: "Присутня 🪖");


        }
    }
}
