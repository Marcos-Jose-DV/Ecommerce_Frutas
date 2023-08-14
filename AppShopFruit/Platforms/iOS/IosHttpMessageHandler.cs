

using AppShopFruit.Interfaces;
using Security;

namespace AppShopFruit.Platforms.iOS;

public class IosHttpMessageHandler : IPlatformHttpMessageHandler
{
    public HttpMessageHandler GetHttpMessageHandler() =>
        new NSUrlSessionHandler
        {
            TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust)
                => url.StartsWith("http://localhost")
        };
}
