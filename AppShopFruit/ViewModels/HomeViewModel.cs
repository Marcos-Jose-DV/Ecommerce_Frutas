using AppShopFruit.Models;
using AppShopFruit.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AppShopFruit.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly CategoryService _categoryService;
    private readonly OffersServices _offersServices;
    public HomeViewModel(CategoryService categoryService, OffersServices offersServices)
    {
        _categoryService = categoryService;
        _offersServices = offersServices;
    }
    public ObservableCollection<Category> Categories { get; set; } = new();
    public ObservableCollection<Offer> Offers { get; set; } = new();
    public async Task InitializeAsync()
    {
        var offrsTask = _offersServices.GetOffersAsync();
        foreach (var category in await _categoryService.GetMainCategoriesAsync())
        {
            Categories.Add(category);
        }
        foreach (var offer in await offrsTask)
        {
            Offers.Add(offer);
        }
    }
}
