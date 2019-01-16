// Install the C# / .NET helper library from twilio.com/docs/csharp/install

using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace NamespacesLesson15_01_19
{
    public static class SMS
    {
        public static void GetSms(string phone, string number)
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "ACaf5825a2de837d652356021ed33d5f68";
            const string authToken = "7a60437ac22d3a3858df8b8e63298ce4";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: number,
                from: new Twilio.Types.PhoneNumber("+17402992037"),
                to: new Twilio.Types.PhoneNumber(phone)
            );
        }
    }
}
