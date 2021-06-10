using System.Text.Json.Serialization;

namespace GpuStockNotifier.Common
{
    public class Gpu
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("apiUrl")]
        public string ApiUrl { get; set; }

        [JsonPropertyName("storeUrl")]
        public string StoreUrl { get; set; }

        public string LdlcUrl { get; set; } = string.Empty;

        public string Subject => $"{Name} AVAILABLE!!!";
        public string Body => $"{Name} available at {LdlcUrl}";
    }
}
