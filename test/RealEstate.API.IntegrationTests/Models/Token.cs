using System.Text.Json.Serialization;

namespace RealEstate.API.IntegrationTests.Models
{
    public class Token
    {
        
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
    }
}
