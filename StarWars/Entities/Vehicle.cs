using StarWars.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StarWars.Contracts.Dto;
using StarWars.Dto;

namespace StarWars.Entities
{
    [Resource(Name = "vehicles")]
    public class Vehicle : StarWarsEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("cost_in_credits")]
        public string CostInCredits { get; set; }

        [JsonPropertyName("length")]
        public string Length { get; set; }

        [JsonPropertyName("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        [JsonPropertyName("crew")]
        public string Crew { get; set; }

        [JsonPropertyName("passengers")]
        public string Passengers { get; set; }

        [JsonPropertyName("cargo_capacity")]
        public string CargoCapacity { get; set; }

        [JsonPropertyName("consumables")]
        public string Consumables { get; set; }

        [JsonPropertyName("vehicle_class")]
        public string VehicleClass { get; set; }

        [JsonPropertyName("pilots")]
        public List<object> Pilots { get; set; }

        [JsonPropertyName("films")]
        public List<string> Films { get; set; }

        public VehicleDto ToDto()
        {
            return new VehicleDto()
            {
                Name = Name,
                Manufacturer = Manufacturer,
                Model = Model,
                Passengers = Passengers,
                Crew = Crew,
                Length = Length
            };
        }
    }
}
