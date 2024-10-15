using Telegram.Bot;
using Telegram.Bot.Types;

namespace lab_4.Controllers
{
    public class UpdateDistributor<T> where T : ITelegramUpdateListener
    {
        private Dictionary<long, T> listeners;
        private readonly Func<TelegramBotClient, T> listenerFactory;

        public UpdateDistributor(Func<TelegramBotClient, T> listenerFactory)
        {
            listeners = new Dictionary<long, T>();
            this.listenerFactory = listenerFactory;
        }

        public async Task GetUpdate(Update update, TelegramBotClient botClient)
        {
            long chatId = update.Message.Chat.Id;
            if (!listeners.TryGetValue(chatId, out T? listener))
            {

                listener = listenerFactory(botClient);
                listeners[chatId] = listener;
            }

            await listener.GetUpdate(update);
        }
    }
}
