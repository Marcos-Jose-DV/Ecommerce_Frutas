using AppShopFruit.Constants;
using AppShopFruit.Models;
using System.Text.Json;

namespace AppShopFruit.Services;

public class OffersServices
{
    private readonly IHttpClientFactory _httpClientFactory;
    public OffersServices(IHttpClientFactory httpClientBuilder)
     => _httpClientFactory = httpClientBuilder;

    public async Task<IEnumerable<Offer>> GetOffersAsync()
    {
        var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
        var response = await httpClient.GetAsync("/masters/offers");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
                return JsonSerializer.Deserialize<IEnumerable<Offer>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        return Enumerable.Empty<Offer>();

    }
}

