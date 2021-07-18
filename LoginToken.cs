using System.Text.Json.Serialization;

namespace HttpConsoleApp
{
    public class LoginToken
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}