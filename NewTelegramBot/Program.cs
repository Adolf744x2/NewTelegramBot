using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot.Examples.Polling;
using Telegram.Bot.Extensions.Polling;

namespace NewTelegramBot
{
    class Program
    {
        private static string token { get; set; } = "5363694948:AAF6fkkHl6xvcag1DVCZdrgEpsdN0TgW1Zw";
        private static TelegramBotClient Bot;
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient(token);

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
            Bot.StartReceiving(Handlers.HandleUpdateAsync,
                               Handlers.HandleErrorAsync,
                               receiverOptions,
                               cts.Token);

            Console.WriteLine($"" +
                $"Бот запущен и ждет сообщения...");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }
    }
}

//5363694948:AAF6fkkHl6xvcag1DVCZdrgEpsdN0TgW1Zw    Telegram_Bot
