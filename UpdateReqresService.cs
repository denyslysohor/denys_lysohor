using System;
using System.Text.Json.Serialization;

namespace HttpConsoleApp
{
    public class UpdateReqresService
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("job")]
        public string Job { get; set; }
        [JsonPropertyName("updateAt")]
        public DateTime UpdateAt { get; set; }
    }
}