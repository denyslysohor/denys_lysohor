using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HttpConsoleApp
{
    public class SingleObjectReqres<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}