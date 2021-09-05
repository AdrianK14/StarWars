using StarWars.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWars
{
    public class GetAllResponse<TEntity> where TEntity : StarWarsEntity
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("results")]
        public List<TEntity> Results { get; set; }
    }
}
