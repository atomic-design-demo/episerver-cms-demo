using System;
using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Features.Button.Models;
using AtomicDesignDemo.Features.Category.Models;
using AtomicDesignDemo.Models;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace AtomicDesignDemo.Features.Product.Models
{
    [ContentType(
        GUID = "ed2066e0-2eaf-49d8-ae82-3f83903315ac",
        DisplayName = "Product Page",
        GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new Type[] { },
        IncludeOn = new[] { typeof(CategoryPage) })]
    public class ProductPage : BasePageData
    {
        [Display(
            Name = "Featured Image",
            Order = 10)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual ContentReference FeaturedImage { get; set; }

        [Display(
            Name = "Featured Image Alternative Text",
            Order = 20)]
        [CultureSpecific]
        public virtual string FeaturedImageAlternativeText { get; set; }

        [Display(
            Name = "Excerpt",
            Order = 25)]
        [CultureSpecific]
        public virtual string Excerpt { get; set; }

        [Display(
            Name = "Product Description",
            Order = 27)]
        [CultureSpecific]
        public virtual XhtmlString ProductDescription { get; set; }

        [Display(
            Name = "Price",
            Order = 30)]
        [CultureSpecific]
        public virtual double Price { get; set; }

        [Display(
            Name = "One Sale",
            Order = 40)]
        [CultureSpecific]
        public virtual bool IsOnSale { get; set; }

        [Display(
            Name = "Recommended retail price",
            Order = 50)]
        [CultureSpecific]
        public virtual double RrpPrice { get; set; }

        [Display(
            Name = "Button",
            Order = 60)]
        [CultureSpecific]
        [AllowedTypes(typeof(ButtonBlock))]
        public virtual ContentArea Buttons { get; set; }

        [Display(
            Name = "Related Items",
            Order = 100)]
        [CultureSpecific]
        [AllowedTypes(typeof(ProductPage))]
        public virtual ContentArea RelatedItems { get; set; }
    }
}
