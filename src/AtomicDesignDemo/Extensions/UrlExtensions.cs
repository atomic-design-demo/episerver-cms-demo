using System;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;

namespace AtomicDesignDemo.Extensions
{
    public static class UrlExtensions
    {
        private static Lazy<IUrlResolver> UrlResolver => new Lazy<IUrlResolver>(() => ServiceLocator.Current.GetInstance<IUrlResolver>());

        public static string ToFriendlyUrl(this Url internalUrl)
        {
            if (internalUrl.IsNullOrEmpty())
            {
                return string.Empty;
            }

            UrlBuilder url = new UrlBuilder(internalUrl);

            return UrlResolver.Value.GetUrl(url, new UrlResolverArguments { ContextMode = ContextMode.Default }) ?? string.Empty;
        }

        public static bool IsNullOrEmpty(this Url internalUrl)
        {
            return internalUrl == null || internalUrl.IsEmpty();
        }
    }
}
