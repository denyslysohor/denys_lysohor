using System.Text.Json.Serialization;

namespace HttpConsoleApp
{
    public class UserRegistration
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}