using System.Diagnostics.CodeAnalysis;

namespace CrimeAPI.Models.Statistics
{
    /// <summary>
    /// Class for displaying statistics for Ethnicity groups
    /// </summary>
    public class EthnicityStat
    {
        public required string EthnicityTitle { get; set; } 
        public required int Count { get; set; }

        [SetsRequiredMembers]
        public EthnicityStat(string ethnicityTitle, int count)
        {
            EthnicityTitle = ethnicityTitle;
            Count = count;
        }
    }
}