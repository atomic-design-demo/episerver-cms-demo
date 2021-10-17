using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AtomicDesignDemo.Models
{
    public class BasePageData : PageData
    {
        public string Title => Name;

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [CultureSpecific]
        public virtual XhtmlString Description { get; set; }
    }
}
