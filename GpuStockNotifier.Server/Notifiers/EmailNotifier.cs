using GpuStockNotifier.Common;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace GpuStockNotifier.Server
{
    class EmailNotifier: NotifierDecorator
    {
        private readonly EmailConfig _config;
        private readonly SmtpClient _client;
        
        public EmailNotifier(Notifier notifier): base(notifier) {
            var filePath = "config.json";
            string jsonConfig = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<Config>(jsonConfig);
            _config = config.Email;

            _client = new SmtpClient(_config.Server)
            {
                Port = _config.Port,
                Credentials = new NetworkCredential(_config.User, _config.Password),
                EnableSsl = true
            };
        }

        private void SendEmail(string subject, string body)
        {
            var message = new MailMessage(_config.User, _config.To)
            {
                Subject = subject,
                Body = body
            };

            _client.Send(message);
            Console.WriteLine("Email sent");
        }

        public override void Notify(Gpu gpu)
        {
            base.Notify(gpu);

            SendEmail(gpu.Subject, gpu.Body);
        }
    }
}
