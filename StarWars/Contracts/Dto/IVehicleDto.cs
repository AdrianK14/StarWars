using System.Text.Json.Serialization;

namespace StarWars.Contracts.Dto
{
    public interface IVehicleDto
    {
        [JsonPropertyName("name")]
        string Name { get; set; }

        [JsonPropertyName("model")]
        string Model { get; set; }

        [JsonPropertyName("manufacturer")]
        string Manufacturer { get; set; }

        [JsonPropertyName("length")]
        string Length { get; set; }

        [JsonPropertyName("crew")]
        string Crew { get; set; }

        [JsonPropertyName("passengers")]
        string Passengers { get; set; }
    }
}
