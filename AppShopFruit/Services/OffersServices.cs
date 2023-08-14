using AppShopFruit.Constants;
using AppShopFruit.Models;
using System.Text.Json;

namespace AppShopFruit.Services;

public class OffersServices : BaseApiService
{
    public OffersServices(IHttpClientFactory httpClientBuilder) 
        : base(httpClientBuilder) { }
    
    public async Task<IEnumerable<Offer>> GetOffersAsync()
    {
        var response = await HttpClient.GetAsync("/masters/offers");
        return await HandlerApiResponseAsync(response, Enumerable.Empty<Offer>());
    }
}

