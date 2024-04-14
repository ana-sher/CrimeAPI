using System.Text.Json.Serialization;

namespace CrimeAPI.Models.PoliceUK
{
    /// <summary>
    /// Represents the OutcomeObject class from PoliceUK API.
    /// More info about class and possible values can be found here: https://data.police.uk/docs/method/stops-street/
    /// </summary>
    internal class OutcomeObject
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}