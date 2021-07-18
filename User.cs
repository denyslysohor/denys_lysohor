using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HttpConsoleApp
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }
}