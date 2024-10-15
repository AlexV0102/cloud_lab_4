using Telegram.Bot;
using Telegram.Bot.Types;

namespace lab_4.Controllers.Commands
{
    public interface ICommand
    {
        public string Name { get; }
        public async Task Execute(Update update) { }
    }
}
