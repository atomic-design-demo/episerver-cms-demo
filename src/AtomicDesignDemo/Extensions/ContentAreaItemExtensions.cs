using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;

namespace AtomicDesignDemo.Extensions
{
    public static class ContentAreaItemExtensions
    {
        public static IEnumerable<T> GetContentItems<T>(
            this IEnumerable<ContentAreaItem> contentAreaItems,
            CultureInfo language = null,
            IContentLoader contentLoader = null,
            bool applyFilters = true)
            where T : IContentData
        {
            if (contentAreaItems == null)
            {
                return Enumerable.Empty<T>();
            }

            contentLoader ??= ServiceLocator.Current.GetInstance<IContentLoader>();

            language ??= LanguageSelector.AutoDetect().Language;

            var items = contentLoader.GetItems(contentAreaItems.Select(i => i.ContentLink), language).OfType<T>();

            var publishedFilter = new FilterPublished();
            var accessFilter = new FilterAccess();

            var filterItems =
                applyFilters ? items.OfType<IContent>().Where(x => !publishedFilter.ShouldFilter(x) && !accessFilter.ShouldFilter(x))
                    : items.OfType<IContent>();

            return filterItems.OfType<T>();
        }
    }
}
