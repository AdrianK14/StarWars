using System;
using System.Text.Json.Serialization;

namespace StarWars.Entities
{
    public class StarWarsEntity
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }
    }
}
