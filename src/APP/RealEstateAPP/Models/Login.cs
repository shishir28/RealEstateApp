using System;
using System.Text.Json.Serialization;

namespace RealEstateAPP.Models
{
    public class Login
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
