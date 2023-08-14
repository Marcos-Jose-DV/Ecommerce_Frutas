

using AppShopFruit.Constants;
using AppShopFruit.Models;
using System.Text.Json;

namespace AppShopFruit.Services;

public class BaseApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseApiService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;

    protected JsonSerializerOptions JsonSerializerOptions
      = new() { PropertyNameCaseInsensitive = true };

    protected HttpClient HttpClient
        => _httpClientFactory.CreateClient(AppConstants.HttpClientName);

    protected TData Desirialize<TData>(string jsondata) =>
        JsonSerializer.Deserialize<TData>(jsondata, JsonSerializerOptions);
    protected async Task<TData> HandlerApiResponseAsync<TData>(HttpResponseMessage response, TData defoultValue)
    {
        if (response.IsSuccessStatusCode)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                    return Desirialize<TData>(content);
            }
        }
        return defoultValue;
    }
}
