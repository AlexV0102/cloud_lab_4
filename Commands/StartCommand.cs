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
        new KeyboardButton[] { new("Освітні програми"), new("Військова кафедра") },
        new KeyboardButton[] { new("Як добратися"), new("Офіційний сайт") },
        new KeyboardButton[] { new("Контаки кафедри"), new("Розклад занять") },
        new KeyboardButton[] { new("Exit") },
            })
            {
                ResizeKeyboard = true
            };

        }
    }
}
