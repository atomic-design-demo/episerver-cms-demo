using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Features.Promotion.Models;
using AtomicDesignDemo.Models;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using static AtomicDesignDemo.Global;

namespace AtomicDesignDemo.Features.Home.Models
{
    [ContentType(
        GUID = "9e643bbc-e24e-40fe-bad9-d36181686ac0",
        DisplayName = "Home Page",
        GroupName = Global.GroupNames.Specialized)]
    public class HomePage : BasePageData
    {
        [Display(
            Name = "Navbar Items",
            Order = 1000,
            GroupName = TabNames.Header)]
        [CultureSpecific]
        public virtual LinkItemCollection NavItems { get; set; }

        [Display(
            Name = "Footer Nav Items",
            Order = 2000,
            GroupName = TabNames.Footer)]
        [CultureSpecific]
        public virtual LinkItemCollection FooterNavItems { get; set; }

        [Display(
            Name = "Hero",
            Order = 10)]
        [CultureSpecific]
        public virtual ContentReference Hero { get; set; }

        [Display(
            Name = "Promotions",
            Order = 20)]
        [CultureSpecific]
        [AllowedTypes(typeof(PromotionBlock))]
        public virtual ContentArea Promotions { get; set; }
    }
}
