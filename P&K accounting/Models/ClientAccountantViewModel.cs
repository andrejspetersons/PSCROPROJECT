using System.Text.Json.Serialization;


namespace P_K_accounting.Models
{
    public class ClientAccountantViewModel
    {
        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
