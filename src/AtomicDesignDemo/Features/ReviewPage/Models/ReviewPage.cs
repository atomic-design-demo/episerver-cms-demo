using System;
using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Models;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Features.ReviewPage.Models
{
    [ContentType(
        GUID = "45984a70-4d49-4cac-8e7b-893f8a1bdae8",
        DisplayName = "Review Page",
        GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new Type[] { },
        IncludeOn = new[] { typeof(HomePage) })]
    public class ReviewPage : BasePageData
    {
        [Display(
            Name = "Cart Page",
            Order = 20)]
        public virtual ContentReference CartPage { get; set; }

        [Display(
            Name = "Confirmation Page",
            Order = 30)]
        public virtual ContentReference ConfirmationPage { get; set; }

        [Display(
            Name = "HTML Text",
            Order = 40)]
        [CultureSpecific]
        public virtual XhtmlString HtmlText { get; set; }
    }
}
