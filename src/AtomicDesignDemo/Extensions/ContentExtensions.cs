using EPiServer.Core;
using EPiServer.Web.Routing;

namespace AtomicDesignDemo.Extensions
{
    public static class ContentExtensions
    {
        public static string ToFriendlyUrl(this ContentReference contentReference, string language = null)
        {
            string friendlyUrl = null;

            if (!ContentReference.IsNullOrEmpty(contentReference))
            {
                friendlyUrl = language.IsNotNullOrEmpty()
                    ? UrlResolver.Current.GetUrl(contentReference, language)
                    : UrlResolver.Current.GetUrl(contentReference);
            }

            return friendlyUrl ?? string.Empty;
        }
    }
}
