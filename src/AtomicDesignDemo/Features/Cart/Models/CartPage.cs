using System;
using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Models;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Features.Cart.Models
{
    [ContentType(
        GUID = "801037b4-ae33-4e66-b1c1-fec0095d8eca",
        DisplayName = "Cart Page",
        GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new Type[] { },
        IncludeOn = new[] { typeof(HomePage) })]
    public class CartPage : BasePageData
    {
        [Display(
            Name = "Cart Items",
            Order = 10)]
        [CultureSpecific]
        [AllowedTypes(typeof(ProductPage))]
        public virtual ContentArea CartItems { get; set; }
    }
}
