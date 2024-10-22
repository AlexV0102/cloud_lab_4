using Telegram.Bot.Types;

namespace lab_4.Controllers
{
    public interface ITelegramUpdateListener
    {
        Task GetUpdate(Update update);
    }
}
