using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Models
{
    public class BasePageData : PageData
    {
        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 200)]
        [CultureSpecific]
        public virtual bool HideSiteHeader { get; set; }

        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 300)]
        [CultureSpecific]
        public virtual bool HideSiteFooter { get; set; }
    }
}