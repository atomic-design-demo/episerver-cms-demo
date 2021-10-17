using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Models
{
    public class BasePageData : PageData
    {
        [Display(
            Name = "Title",
            Order = 1)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
            Name = "Hero",
            Order = 10)]
        [CultureSpecific]
        public virtual ContentReference Hero { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [CultureSpecific]
        public virtual XhtmlString Description { get; set; }

        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 100)]
        [CultureSpecific]
        public virtual bool HideNavigation { get; set; }
    }
}
