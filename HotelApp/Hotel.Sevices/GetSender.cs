using Hotel.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Sevices
{
    public static class GetSeneder
    {
        public static ISender GetSender(Sender sender)
        {
            switch (sender)
            {
                case Sender.SmsSender:
                    return new SmsSender();
                case Sender.TelegramSender:
                    return new TelegramBot();
                default:
                    return new TelegramBot();
            }
        }
    }
}
