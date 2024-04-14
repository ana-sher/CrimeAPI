namespace CrimeAPI.Models
{
    /// <summary>
    /// Represents StreetSearch event data.
    /// </summary>
    public class StreetSearch
    {
        public string? AgeRange { get; set; }
        public string? Ethnicity { get; set; }
        public string? Gender { get; set; }
        public string? Legislation { get; set; }
        public Location? Location { get; set; }
        public DateTime Datetime { get; set; }
        public string? Type { get; set; }
    }
}
