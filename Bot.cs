using Telegram.Bot;

namespace lab_4
{
    public class Bot
    {

        private static TelegramBotClient? Client { get; set; }
        public static async Task<TelegramBotClient> GetTelegramBot()
        {
            if (Client != null)
            {
                return Client;
            }
            var configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .Build();

            string token = configuration["TelegramBot:Token"];
            string hook = configuration["TelegramBot:WebhookUrl"];

            Client = new TelegramBotClient(token);
            await Client.SetWebhookAsync(hook);
            await Client.SetWebhookAsync(hook);
            return Client;
        }
    }
}
// Client = new TelegramBotClient("8058207707:AAHwYa7WyWmY4Oxg-EQKgX4zh8FV6VRm7uA");
// string hook = "https://infoaboutmathdepartmentnulp2024-ateyhed8c4f3afhm.canadacentral-01.azurewebsites.net/api/Bot";
