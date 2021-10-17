using System;
using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Models;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;

namespace AtomicDesignDemo.Features.Checkout.Models
{
    [ContentType(
        GUID = "a3426657-0aee-44d6-b747-8ea71aa7aebc",
        DisplayName = "Checkout Page",
        GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new Type[] { },
        IncludeOn = new[] { typeof(HomePage) })]
    public class CheckOutPage : BasePageData
    {
        [Display(
            Name = "Checkout Form",
            Order = 10)]
        [AllowedTypes(typeof(FormContainerBlock))]
        public virtual ContentArea CheckoutForm { get; set; }

        [Display(
            Name = "Review Page",
            Order = 20)]
        public virtual ContentReference ReviewPage { get; set; }
    }
}
