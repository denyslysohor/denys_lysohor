using System;
using System.Text.Json.Serialization;

namespace HttpConsoleApp
{
    public class Response
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("job")]
        public string Job { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime TimeCreating { get; set; }
    }
}