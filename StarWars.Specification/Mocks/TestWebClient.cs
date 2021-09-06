using StarWars.Contracts.SwApiClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StarWars.Specification.Mocks
{
    public class TestWebClient : IWebClient
    {
        public Dictionary<string, string> _responses = new Dictionary<string, string>()
        {
            { "/people/", "people.json"},
            { "/people/1/", "person.json"},
            { "/films/1/", "film.json"},
            { "/films/2/", "film.json"},
            { "/films/3/", "film.json"},
            { "/films/6/", "film.json"},
            { "/vehicles/14/", "vehicle.json"},
            { "/vehicles/30/", "vehicle.json"},
            { "/starships/12/", "starship.json"},
            { "/starships/22/", "starship.json"}
        };

        public string SendRequest(string url)
        {
            return File.ReadAllText($"Mocks/Responses/{_responses[_responses.Keys.First(x => url.EndsWith(x))]}");
        }
    }
}
