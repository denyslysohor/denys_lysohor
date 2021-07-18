using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HttpConsoleApp
{
    public class BaseReqresInfo<T>
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; }
    }
}