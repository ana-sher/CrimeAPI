namespace CrimeAPI.Services
{
    /// <summary>
    /// Base class for HttpClient services.
    /// </summary>
    public abstract class HttpServiceBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILogger<HttpServiceBase> _logger;

        private readonly string _baseAdress;

        public HttpServiceBase(HttpClient httpClient, ILogger<HttpServiceBase> logger, string baseAdress)
        {
            _httpClient = httpClient;
            _logger = logger;
            _baseAdress = baseAdress;
            _httpClient.BaseAddress = new Uri(baseAdress);
        }

        public async Task<T?> GetFromJsonAsync<T>(string requestUri)
        {
            _logger.LogInformation($"Trying to access {_baseAdress}{requestUri}", DateTime.UtcNow.ToLongTimeString());
            return await _httpClient.GetFromJsonAsync<T>(requestUri);

        }
    }
}
