using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{
    public class ExitCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public ExitCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public string Name => "Exit";


        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;

            await _botClient.SendTextMessageAsync(
            chatId,
            text: "До побачення!",
            replyMarkup: new ReplyKeyboardRemove());
        }



    }
}
