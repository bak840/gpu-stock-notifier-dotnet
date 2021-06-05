using GpuStockNotifier.Common;
using System;
using System.IO;
using System.Text.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace GpuStockNotifier.Server
{
    class SmsNotifier : NotifierDecorator
    {
        private SmsConfig _config;

        public SmsNotifier(Notifier notifier) : base(notifier)
        {
            var filePath = "config.json";
            string jsonConfig = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<Config>(jsonConfig);
            _config = config.Sms;

            TwilioClient.Init(_config.TwilioAccountId, _config.TwilioAuthToken);
        }

        private void SendSms(string body)
        {
            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(_config.From),
                to: new Twilio.Types.PhoneNumber(_config.To)
            );

            Console.WriteLine(message.Sid);
        }

        public override void Notify(Gpu gpu)
        {
            base.Notify(gpu);

            SendSms(gpu.Body);
        }
    }
}
