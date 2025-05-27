using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace TestAPI.Models
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public List<Employees> Employees { get; set; } = new();
        public List<News> News { get; set; } = new();
        public List<Events> Events { get; set; } = new();

        public IndexModel(HttpClient httpClient) { _httpClient = httpClient; }

        public async Task OnGetAsync()
        {
            Employees = await GetApiData<List<Employees>>("api/v1/employees");
            News = await GetApiData<List<News>>("api/v1/news");
            Events = await GetApiData<List<Events>>("api/v1/events");
        }
        private async Task<T> GetApiData<T>(string endpoint)
        {
            var response = await _httpClient.GetStringAsync(endpoint);
            return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
