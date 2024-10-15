using lab_4.Controllers.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace lab_4.Controllers
{
    public class CommandExecutor : ITelegramUpdateListener
    {
        private List<ICommand> _commands;
        private readonly TelegramBotClient _botClient;

        public CommandExecutor(TelegramBotClient botClient)
        {
            _botClient = botClient;


            _commands = new List<ICommand>()
            {
                new StartCommand(_botClient),
                new SpecialtiesCommand(_botClient),
                new EducationalProgramsCommand(_botClient),
                new MilitaryDepartmentCommand(_botClient),
                new HowToGetThereCommand(_botClient),
                new OfficialSiteCommand(_botClient),
                new ExitCommand(_botClient)
            };
        }
        public async Task GetUpdate(Update update)
        {
            Message msg = update.Message;
            ICommand searchCommand = _commands.FirstOrDefault(command => command.Name == msg.Text);
            if (searchCommand != null)
            {
                await searchCommand.Execute(update);
            }
            else
                await new NotFoundCommand(_botClient).Execute(update);
        }
    }
}
