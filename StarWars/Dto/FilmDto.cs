using System.Text.Json.Serialization;
using StarWars.Contracts.Dto;

namespace StarWars.Dto
{
    public class FilmDto : IFilmDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("episode_id")]
        public int EpisodeId { get; set; }

        [JsonPropertyName("director")]
        public string Director { get; set; }

        [JsonPropertyName("producer")]
        public string Producer { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
    }
}
