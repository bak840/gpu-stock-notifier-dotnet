using System.Text.Json.Serialization;

namespace GpuStockNotifier.Server
{
    public class EmailConfig
    {
        [JsonPropertyName("server")]
        public string Server { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }
    }

    public class SmsConfig
    {
        [JsonPropertyName("twilioAccountId")]
        public string TwilioAccountId { get; set; }

        [JsonPropertyName("twilioAuthToken")]
        public string TwilioAuthToken { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }
    }

    public class Config
    {
        [JsonPropertyName("email")]
        public EmailConfig Email { get; set; }

        [JsonPropertyName("sms")]
        public SmsConfig Sms { get; set; }
    }
}
