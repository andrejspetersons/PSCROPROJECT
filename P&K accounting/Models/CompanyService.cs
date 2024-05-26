using System.Text.Json.Serialization;

namespace P_K_accounting.Models
{
    public class CompanyService
    {
        [JsonPropertyName("id")]
        public int ServiceId { get; set; }
        [JsonPropertyName("name")]
        public string ServiceName { get; set; }
    }
}
