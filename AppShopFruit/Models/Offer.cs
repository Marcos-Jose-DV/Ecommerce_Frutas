using static AndroidX.ConstraintLayout.Core.Motion.Utils.HyperSpline;

namespace AppShopFruit.Models;

public class Offer
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string BgColor { get; set; }

    //public Color BackgroundColor => Color.FromArgb(BgColor);

    //public Offer(string title, string description, Color bgColor, string code)
    //{
    //    Title = title;
    //    Description = description;
    //    Code = code;
    //    BgColor = bgColor;
    //}

    //    private static readonly string[] _ligthColors = new string[]
    //    {
    //        "#5e412f","#fcebb6","#78c0a8","#f07818","#f0a830","#f75e50","#eac761"
    //    };

    //    private static Color RandomColor => Color.FromArgb(_ligthColors.OrderBy(x => Guid.NewGuid()).First());
    //    public static IEnumerable<Offer> GetOffers()
    //    {
    //        yield return new Offer("Upto 30% off", "Enjoy upto 30% off on all fruits", RandomColor, "FRT30");
    //        yield return new Offer("Green Veg Big Sale 50% OFF", "Enjoy our big offer of 50% off on all green vegetables", RandomColor, "50OFF");
    //        yield return new Offer("Flat 100 OFF", "Flat Rs. 100 off on all exotic fruits and vegetables", RandomColor, "EXT100");
    //        yield return new Offer("25% OFF on Seasonal Fruits", "Enjoy 25% off on all seasonal fruits", RandomColor, "FRT25");
    //    }
}
