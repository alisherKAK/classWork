using Hotel.Services.Abstract;
using System.Diagnostics;
using Telegram.Bot;

namespace Hotel.Sevices
{
    public class TelegramBot : IReporter
    {
        private TelegramBotClient bot = new TelegramBotClient("854986882:AAETCnIbl83piEGDyoAnizBA4eN87hE_HJo");

        public void Open()
        {
            bot.StartReceiving();
        }

        public void Close()
        {
            bot.StopReceiving();
        }

        public void Send(string text)
        {
            bot.OnMessage += Bot_OnMessage;
            bot.OnMessageEdited += Bot_OnMessage;

            Process.Start("https://web.telegram.org/#/im?p=@StepCodeSendMessageBot");
        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text.Trim() == ".")
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                        "Command List:\n" +
                        "1)Get code");
                }
                else if (e.Message.Text == "Get code" || e.Message.Text == "get code")
                {
                    CodeGenerator.GenerateCode();
                    bot.SendTextMessageAsync(e.Message.Chat.Id, CodeGenerator.Code);

                }
            }
        }
    }
}
