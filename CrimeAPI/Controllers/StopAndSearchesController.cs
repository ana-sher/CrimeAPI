using CrimeAPI.Helpers;
using CrimeAPI.Models;
using CrimeAPI.Models.Statistics;
using CrimeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrimeAPI.Controllers
{
    /// <summary>
    /// Controller for handling StreetSearches data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StopAndSearchesController(PoliceUKService policeUKService) : ControllerBase
    {
        private readonly PoliceUKService _policeUKService = policeUKService;

        /// <summary>
        /// Get StreetSearches within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="lat" example="52.629729">Latitude of the centre of the desired area.</param>
        /// <param name="lng" example="-1.131592">Longitude of the centre of the desired area.</param>
        /// <param name="date" example="2022-06">(YYYY-MM) Limit results to a specific month.</param>
        /// <returns>StreetSearches array</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StreetSearch>>> Get([FromQuery] double lat, double lng, DateOnly date)
        {
            return Ok(await GetStreatSearches(lat, lng, date));
        }

        /// <summary>
        /// Get LocationGroups of StreetSearches within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="lat" example="52.629729">Latitude of the centre of the desired area.</param>
        /// <param name="lng" example="-1.131592">Longitude of the centre of the desired area.</param>
        /// <param name="date" example="2022-06">(YYYY-MM) Limit results to a specific month.</param>
        /// <returns>Dictionary with List of StreetSearches grouped by Location</returns>
        [HttpGet("LocationGroups")]
        public async Task<ActionResult<IDictionary<string, List<StreetSearch>>>> GetLocationGroups([FromQuery] double lat, double lng, DateOnly date)
        {
            var resp = await GetStreatSearches(lat, lng, date);
            var result = resp
                .Where(el=>el.Location != null)
                .ToDictionaryWithDuplicateKeys(el => $"{el.Location.Latitude},{el.Location.Longitude}");

            return Ok(result);
        }

        /// <summary>
        /// Get Statistics of StreetSearches within a 1 mile radius of a single point by Age and Ethnicity.
        /// </summary>
        /// <param name="lat" example="52.629729">Latitude of the centre of the desired area.</param>
        /// <param name="lng" example="-1.131592">Longitude of the centre of the desired area.</param>
        /// <param name="date" example="2022-06">(YYYY-MM) Limit results to a specific month.</param>
        /// <returns>Statistics data array</returns>
        [HttpGet("Statistics")]
        public async Task<ActionResult<IEnumerable<AgeEthnicityStat>>> GetStatistics([FromQuery] double lat, double lng, DateOnly date)
        {
            var resp = await GetStreatSearches(lat, lng, date);
            var result = resp
                .Where(el => el.AgeRange != null && el.Ethnicity != null)
                // grouping by age range
                .ToDictionaryWithDuplicateKeys(el => el.AgeRange);
                
            var statData = new List<AgeEthnicityStat>();
            foreach (var kvp in result)
            {
                // grouping inside age group by ethnicity
                var ethnicityStat = kvp.Value.ToDictionaryWithDuplicateKeys(el=>el.Ethnicity)
                    // displaying amount of stops with this ethnicity in this age group
                    .Select(el=>new EthnicityStat(el.Key, el.Value.Count));

                var newStat = new AgeEthnicityStat(kvp.Key, ethnicityStat);
                statData.Add(newStat);
            }

            return Ok(statData);
        }

        private async Task<IEnumerable<StreetSearch>> GetStreatSearches(double lat, double lng, DateOnly date)
        {
            var resp = await _policeUKService.GetStopAndSearchesAsync(lat, lng, date);
            if (resp != null)
            {
                return resp.Select(el => el.ConvertToStreetSearch());
            }
            return [];
        }
    }
}
