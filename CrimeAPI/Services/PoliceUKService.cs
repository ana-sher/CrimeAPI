using CrimeAPI.Models.PoliceUK;

namespace CrimeAPI.Services
{
    /// <summary>
    /// Service for Http requests to PoliceUK API
    /// </summary>
    public class PoliceUKService(HttpClient httpClient, ILogger<PoliceUKService> logger) : HttpServiceBase(httpClient, logger, _baseUrl)
    {
        private const string _baseUrl = "https://data.police.uk/api/";

        internal async Task<IEnumerable<StopAndSearch>?> GetStopAndSearchesAsync(double lat, double lng, DateOnly date)
        {
            return await GetFromJsonAsync<IEnumerable<StopAndSearch>>($"stops-street?lat={lat}&lng={lng}&date={date.Year}-{date.Month}");
        }
    }
}
