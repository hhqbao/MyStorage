using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MyStorage.Core.Models
{
    public class TwilioLibrary
    {
        private const string FROM_NUMBER = "+61427046184";
        private const string ACCOUNT_SID = "ACa5a9a079c6a833d3dbe67ff6895a3008";
        private const string AUTH_TOKEN = "f07b4cc2ec2675592e9a41dadf762e1e";

        public string ReceiverNumber { get; set; }

        public string Message { get; set; }

        public TwilioLibrary(string receiverNumber, string message)
        {
            ReceiverNumber = receiverNumber;
            Message = message;
            TwilioClient.Init(ACCOUNT_SID, AUTH_TOKEN);
        }

        public void SendSMS()
        {
            var message = MessageResource.Create(
                to: new PhoneNumber(ReceiverNumber),
                @from: new PhoneNumber(FROM_NUMBER),
                body: Message
                );
        }
    }
}