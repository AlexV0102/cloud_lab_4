using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{
    public class EducationalProgramsCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public EducationalProgramsCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public string Name => "Освітні програми";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;


            await _botClient.SendTextMessageAsync(
                chatId,
                text: "Виберіть напрям програми",
                replyMarkup: GetEducationalProgramsInlineKeyboard());


        }


        private InlineKeyboardMarkup GetEducationalProgramsInlineKeyboard()
        {
            return new InlineKeyboardMarkup(new List<InlineKeyboardButton[]>
            {
                new InlineKeyboardButton[] { InlineKeyboardButton.WithUrl("Прикладна математика та інформатика", "https://amath.lp.edu.ua/programs") },
                new InlineKeyboardButton[] { InlineKeyboardButton.WithUrl("Фінансовий інжинирінг", "https://amath.lp.edu.ua/programs") },
            });
        }
    }
}
