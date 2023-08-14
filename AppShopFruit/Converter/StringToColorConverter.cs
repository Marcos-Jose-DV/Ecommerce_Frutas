

using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace AppShopFruit.Converter;

internal class StringToColorConverter : BaseConverter<string, Color>
{
    public override Color DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override string DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override string ConvertBackTo(Color value, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override Color ConvertFrom(string value, CultureInfo culture)
        => Color.FromArgb(value);
}
