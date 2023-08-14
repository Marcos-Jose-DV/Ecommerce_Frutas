

using CommunityToolkit.Mvvm.ComponentModel;

namespace AppShopFruit.Models;

public class Category
{
    public Category(int id, string name, short parentId, string image, string credit)
    {
        Id = id;
        Name = name;
        Image = image;
        ParentId = parentId;
        Credit = credit;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    //public  string  Image { get; set; }
    private string _image;
    public string Image
    {
        get => _image;
        set
        {
            _image = $"https://github.com/Marcos-Jose-DV/Curso-Net-Maui/blob/main/AppShopFruit/AppShopFruitApi/wwwroot/images/categories/{value}";
        }
    }

    public short ParentId { get; set; }
    public string Credit { get; set; }
    public bool IsMainCategory => ParentId == 0;
    //public string ImageUrl => $"https://localhost:7051/images/categories/{Image}";
}
