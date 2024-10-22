using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{
    public class ContactsCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public ContactsCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public string Name => "Контаки кафедри";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;

            await _botClient.SendTextMessageAsync(
            chatId,
            text: "Номер телефону: +38 (032) 258-23-68, " +
                      "\nЕлектронна адресса: pm.dept@lpnu.ua");
        }
    }
}
