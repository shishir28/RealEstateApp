using System.Text.Json.Serialization;

namespace RealEstate.API.IntegrationTests.Models
{
    public class Register
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

    }
}
