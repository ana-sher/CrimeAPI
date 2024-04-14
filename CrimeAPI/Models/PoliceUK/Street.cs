using System.Text.Json.Serialization;

namespace CrimeAPI.Models.PoliceUK
{
    /// <summary>
    /// Represents the Street class from PoliceUK API.
    /// More info about class and possible values can be found here: https://data.police.uk/docs/method/stops-street/
    /// </summary>
    internal class Street
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}