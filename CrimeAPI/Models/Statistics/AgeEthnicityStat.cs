using System.Diagnostics.CodeAnalysis;

namespace CrimeAPI.Models.Statistics
{
    /// <summary>
    /// Class for displaying statistics for Age groups, divided by Ethnicity
    /// </summary>
    public class AgeEthnicityStat
    {
        public required string AgeRange { get; set; } 
        public required IEnumerable<EthnicityStat> EthnicityStats { get; set; }
        [SetsRequiredMembers]
        public AgeEthnicityStat(string ageRange, IEnumerable<EthnicityStat> ethnicityStats)
        {
            AgeRange = ageRange;
            EthnicityStats = ethnicityStats;
        }
    }
}
