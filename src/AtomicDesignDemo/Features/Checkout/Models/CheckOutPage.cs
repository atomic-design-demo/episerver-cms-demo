using System;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Models;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

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
    }
}
