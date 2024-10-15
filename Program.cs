using Telegram.Bot;
using Telegram.Bot.Polling;
using Microsoft.Extensions.Configuration;
using lab_4.BotConfig;
using lab_4.Controllers;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var botConfig = config.GetSection("BotConfig").Get<BotConfiguration>();

        var botClient = new TelegramBotClient(botConfig.BotToken);
        var updateDistributor = new UpdateDistributor<CommandExecutor>(botClient =>
       {
           return new CommandExecutor(botClient);
       });


        using var cts = new CancellationTokenSource();
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = []
        };

        botClient.StartReceiving(
            async (botClient, update, cancellationToken) =>
            {

                if (update.Message != null)
                {
                    await updateDistributor.GetUpdate(update, (TelegramBotClient)botClient);
                }
            },
            async (botClient, exception, cancellationToken) =>
            {

                Console.WriteLine($"Error: {exception.Message}");
            },
            receiverOptions,
            cancellationToken: cts.Token
        );

        Console.WriteLine("Bot is up and running...");
        Console.ReadLine();

        cts.Cancel();
    }
}
