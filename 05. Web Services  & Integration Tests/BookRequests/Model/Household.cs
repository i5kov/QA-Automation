using System;
using Newtonsoft.Json;

namespace BookRequests.Model
{
    public class Household
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        public static Household FromJson(string json) => JsonConvert.DeserializeObject<Household>(json, Helper.Settings);
    }
}