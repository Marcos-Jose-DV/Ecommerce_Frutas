namespace AppShopFruit.Controls;

public partial class Spacer : ContentView
{
	public Spacer()
	{
		InitializeComponent();
	}
	public static readonly BindableProperty SpacePropery = 
		BindableProperty.Create(nameof(Space), typeof(int), typeof(Spacer),defaultValue:10);

	public int Space
	{
		get => (int)GetValue(SpacePropery);
		set  => SetValue(SpacePropery, value);
	}
}