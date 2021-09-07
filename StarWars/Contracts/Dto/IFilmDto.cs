using System.Text.Json.Serialization;

namespace StarWars.Contracts.Dto
{
    public interface IFilmDto
    {
        [JsonPropertyName("title")]
        string Title { get; set; }

        [JsonPropertyName("episode_id")]
        int EpisodeId { get; set; }

        [JsonPropertyName("director")]
        string Director { get; set; }

        [JsonPropertyName("producer")]
        string Producer { get; set; }

        [JsonPropertyName("release_date")]
        string ReleaseDate { get; set; }
    }
}
