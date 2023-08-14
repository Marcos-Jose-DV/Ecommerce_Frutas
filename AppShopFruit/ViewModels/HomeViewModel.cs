using AppFruit.Shared.Dtos;
using AppShopFruit.Models;
using AppShopFruit.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AppShopFruit.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly CategoryService _categoryService;
    private readonly OffersServices _offersServices;
    private readonly ProductsService _productsService;
    public HomeViewModel
        (CategoryService categoryService, 
        OffersServices offersServices, 
        ProductsService productsService)
    {
        _categoryService = categoryService;
        _offersServices = offersServices;
        _productsService = productsService;
    }
    public ObservableCollection<Category> Categories { get; set; } = new();
    public ObservableCollection<Offer> Offers { get; set; } = new();
    public ObservableCollection<ProductDto> PopularProducts { get; set; } = new();

    [ObservableProperty]
    private bool _isBusy = true;
    public async Task InitializeAsync()
    {
        try
        {
            var offersTask = _offersServices.GetOffersAsync();
            var popularProductsTasck = _productsService.GetPopularProductsAsync();
            var categoriesTask = _categoryService.GetCategoriesAsync();
            foreach (var category in await _categoryService.GetCategoriesAsync())
            {
                Categories.Add(category);
            }
            foreach (var offer in await offersTask)
            {
                Offers.Add(offer);
            }
            foreach (var product in await popularProductsTasck)
            {
                PopularProducts.Add(product);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
