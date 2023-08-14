using AppShopFruit.Interfaces;
using System.Net.Security;
using Xamarin.Android.Net;

namespace AppShopFruit.Platforms.Android;

class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
{
    public HttpMessageHandler GetHttpMessageHandler() =>
        new AndroidMessageHandler
        {
            ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                certificate.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None
        };

}