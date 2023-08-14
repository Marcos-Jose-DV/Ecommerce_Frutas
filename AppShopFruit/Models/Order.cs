

using AppFruit.Shared;
using AppShopFruit.Models;

public class Order
{
    public long Id { get; set; }
    public IEnumerable<CarItem> Items { get; set; } = Enumerable.Empty<CarItem>();
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal TotalAmount => Items.Sum(x => x.Amount);

    public OrderStatus Status { get; set; } = OrderStatus.Placed;
    public Color Color => _orderStatusColorMap[Status];
    public static readonly IReadOnlyDictionary<OrderStatus, Color> _orderStatusColorMap =
        new Dictionary<OrderStatus, Color>
        {
            [OrderStatus.Placed] = Colors.Yellow,
            [OrderStatus.Confirmed] = Colors.Blue,
            [OrderStatus.Delivered] = Colors.Green,
            [OrderStatus.Cancelled] = Colors.Red

        };
}
