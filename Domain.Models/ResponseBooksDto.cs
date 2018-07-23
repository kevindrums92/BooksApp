using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Domain.Models
{
    public class ResponseBooksDto
    {
        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("Time")]
        public double Time { get; set; }

        [JsonProperty("Total")]
        public long Total { get; set; }

        [JsonProperty("Page")]
        public long Page { get; set; }

        [JsonProperty("Books")]
        public List<Book> Books { get; set; }
    }
}
