using Hotel.Services.Abstract;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Hotel.Sevices
{
    public class SmsSender : ISender
    {
        public string Phone { get; set; }

        public SmsSender(){}

        public SmsSender(string phone)
        {
            Phone = phone;
        } 

        public void Send(string text)
        {
            const string accountSid = "AC5db515f31f3577d4d4f09c12e0e51fe6";
            const string authToken = "9e576aefbb23ddf0fb49757f2642defc";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("+12028738399"),
                to: new Twilio.Types.PhoneNumber(Phone)
            );
        }

        public void Open(){}

        public void Close(){}
    }
}
