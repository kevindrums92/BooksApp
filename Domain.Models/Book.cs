using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Domain.Models
{
    public class Book
    {
        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("SubTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string SubTitle { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }
}
