using AppShopFruit.Interfaces;
using AppShopFruit.Services;
using AppShopFruit.ViewModels;
using AppShopFruit.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace AppShopFruit;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
            })
            .UseMauiCommunityToolkit();

        builder.Services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
        {
#if ANDROID
			return new Platforms.Android.AndroidHttpMessageHandler();
#elif IOS
            return new Platforms.iOS.IosHttpMessageHandler();
#endif

        });



        builder.Services.AddHttpClient(Constants.AppConstants.HttpClientName, httpClient =>
        {
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:07051"
                : "https://localhost:7051";

            httpClient.BaseAddress = new Uri(baseAddress);

        }).ConfigureHttpMessageHandlerBuilder(configBuilder =>
        {
            var platformHttpMessageHandler = configBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
            configBuilder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
        });

        builder.Services.AddSingleton<CategoryService>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<OffersServices>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
