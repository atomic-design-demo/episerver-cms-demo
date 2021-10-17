using System.Collections.Generic;
using EPiServer.Core;

namespace AtomicDesignDemo.Extensions
{
    public static class ContentAreaExtensions
    {
        public static IEnumerable<T> GetElementsOfType<T>(this ContentArea contentArea) where T : IContentData
        {
            return contentArea?.FilteredItems?.GetContentItems<T>(null, null, false);
        }
    }
}
