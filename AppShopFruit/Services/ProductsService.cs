using AppFruit.Shared.Dtos;
using AppShopFruit.Models;

namespace AppShopFruit.Services;

public class ProductsService : BaseApiService
{
    public ProductsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }
    public async Task<IEnumerable<ProductDto>> GetPopularProductsAsync()
    {
        var response = await HttpClient.GetAsync("/popular-products");
        return await HandlerApiResponseAsync(response, Enumerable.Empty<ProductDto>());
    }
}


