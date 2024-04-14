using System.Text.Json.Serialization;

namespace CrimeAPI.Models.PoliceUK
{
    /// <summary>
    /// Represents the Location class from PoliceUK API which is only approximate location of event.
    /// More info about class and possible values can be found here: https://data.police.uk/docs/method/stops-street/
    /// </summary>
    internal class PliceUKLocation
    {
        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }

        [JsonPropertyName("street")]
        public Street? Street { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }

        internal Location ConvertToLocation()
        {
            var resultObj = new Location();

            var latConvered = double.TryParse(Latitude, out double lat);
            if (latConvered)
            {
                resultObj.Latitude = lat;
            }

            var lngConvered = double.TryParse(Longitude, out double lng);
            if (lngConvered)
            {
                resultObj.Longitude = lng;
            }

            return resultObj;
        }
    }
}