using System.Text.Json.Serialization;

namespace CrimeAPI.Models.PoliceUK
{
    /// <summary>
    /// Represents the class for return oblect from PoliceUK API on https://data.police.uk/api/stops-street request.
    /// More info about class and possible values can be found here: https://data.police.uk/docs/method/stops-street/
    /// </summary>
    internal class StopAndSearch
    {
        [JsonPropertyName("age_range")]
        public string? AgeRange { get; set; }

        [JsonPropertyName("outcome")]
        public string? Outcome { get; set; }

        [JsonPropertyName("involved_person")]
        public bool? InvolvedPerson { get; set; }

        [JsonPropertyName("self_defined_ethnicity")]
        public string? SelfDefinedEthnicity { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("legislation")]
        public string? Legislation { get; set; }

        [JsonPropertyName("outcome_linked_to_object_of_search")]
        public bool? OutcomeLinkedToObjectOfSearch { get; set; }

        [JsonPropertyName("datetime")]
        public DateTime Datetime { get; set; }

        [JsonPropertyName("removal_of_more_than_outer_clothing")]
        public bool? RemovalOfMoreThanOuterClothing { get; set; }

        [JsonPropertyName("outcome_object")]
        public OutcomeObject? OutcomeObject { get; set; }

        [JsonPropertyName("location")]
        public PliceUKLocation? Location { get; set; }

        [JsonPropertyName("officer_defined_ethnicity")]
        public string? OfficerDefinedEthnicity { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("operation_name")]
        public string? OperationName { get; set; }

        [JsonPropertyName("object_of_search")]
        public string? ObjectOfSearch { get; set; }

        internal StreetSearch ConvertToStreetSearch()
        {
            var resultObj = new StreetSearch
            {
                Ethnicity = OfficerDefinedEthnicity,
                Type = Type,
                Gender = Gender,
                Datetime = Datetime,
                AgeRange = AgeRange,
                Legislation = Legislation
            };

            if (Location != null)
            {
                resultObj.Location = Location.ConvertToLocation();
            }


            return resultObj;
        }
    }
}
