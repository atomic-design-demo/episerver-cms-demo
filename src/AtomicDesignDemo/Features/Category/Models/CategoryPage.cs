using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Models;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Features.Category.Models
{
    [ContentType(
        GUID = "3d2a7c0b-134e-4c29-9e33-256337f74351",
        DisplayName = "Category Page",
        GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(ProductPage) },
        IncludeOn = new[] { typeof(HomePage) })]
    public class CategoryPage : BasePageData
    {
        [Display(
            Name = "Products",
            Order = 10)]
        [CultureSpecific]
        [AllowedTypes(typeof(ProductPage))]
        public virtual ContentArea Products { get; set; }
    }
}
