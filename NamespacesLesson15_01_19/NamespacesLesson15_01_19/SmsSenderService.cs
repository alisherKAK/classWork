using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace NamespacesLesson15_01_19
{
    public static class SmsSenderService
    {
        public static void GetSms(string phone, string number)
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "AC0922ea8de9b95f735fa72a46e0d20b22";
            const string authToken = "80704fba887741a86773adc338abd6e6";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: number,
                from: new Twilio.Types.PhoneNumber("+16052504026"),
                to: new Twilio.Types.PhoneNumber(phone)
            );
        }
    }
}
