using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace lab_4.Controllers.Commands
{
    public class StartCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public StartCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public string Name => "/start";
        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            await _botClient.SendTextMessageAsync(
                chatId,
                text: "Оберіть варіант:",
                replyMarkup: GetChessboardMainMenuKeyboard());
        }
        private ReplyKeyboardMarkup GetChessboardMainMenuKeyboard()
        {
            return new ReplyKeyboardMarkup(new List<KeyboardButton[]>
            {
        new KeyboardButton[] { new KeyboardButton("Освітні програми"), new KeyboardButton("Військова кафедра") },
        new KeyboardButton[] { new KeyboardButton("Як добратися"), new KeyboardButton("Офіційний сайт") },
        new KeyboardButton[] { new KeyboardButton("Exit") },
            })
            {
                ResizeKeyboard = true
            };

        }
    }
}
