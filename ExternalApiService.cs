namespace WebApplication5.Services
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;

        // Inject HttpClient
        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get data from an external API
        public async Task<string> GetExternalDataAsync(string url)
        {
            // Perform an asynchronous HTTP GET request to the external API
            var response = await _httpClient.GetAsync(url);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            else
            {
                // Handle errors
                return "Error: Unable to fetch data from the external API.";
            }
        }
    }
}
