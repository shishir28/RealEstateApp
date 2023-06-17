using System.Text.Json.Serialization;

namespace RealEstate.API.IntegrationTests.Models
{
    public class Login
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
