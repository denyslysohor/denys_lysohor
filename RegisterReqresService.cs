using System.Text.Json.Serialization;

namespace HttpConsoleApp
{
    public class RegisterReqresService
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}