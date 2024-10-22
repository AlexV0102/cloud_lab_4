using Telegram.Bot.Types;
using Telegram.Bot;

namespace lab_4.Controllers.Commands
{
    public class ScheduleCommand : ICommand
    {
        private readonly TelegramBotClient _botClient;

        public ScheduleCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public string Name => "Розклад занять";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;

            string schedule =
    "1 пара: 8:30 - 9:50\n" +
    "Перерва: 15 хв. (9:50 - 10:05)\n\n" +

    "2 пара: 10:05 - 11:25\n" +
    "Перерва: 15 хв. (11:25 - 11:40)\n\n" +

    "3 пара: 11:40 - 13:00\n" +
    "Перерва: 15 хв. (13:00 - 13:15)\n\n" +

    "4 пара: 13:15 - 14:35\n" +
    "Перерва: 15 хв. (14:35 - 14:50)\n\n" +

    "5 пара: 14:50 - 16:10\n" +
    "Перерва: 15 хв. (16:10 - 16:25)\n\n" +

    "6 пара: 16:25 - 17:45\n" +
    "Перерва: 15 хв. (17:45 - 18:00)\n\n" +

    "7 пара: 18:00 - 19:20\n" +
    "Перерва: 10 хв. (19:20 - 19:30)\n\n" +

    "8 пара: 19:30 - 20:50";

            await _botClient.SendTextMessageAsync(
                chatId,
                text: schedule

            );
        }
    }
}
