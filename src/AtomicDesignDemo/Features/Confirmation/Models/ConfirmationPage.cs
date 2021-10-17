using System;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Models;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Features.Confirmation.Models
{
    [ContentType(
        GUID = "1409c6e6-817f-4ec8-af6a-21729c27909c",
        DisplayName = "Confirmation Page",
        GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new Type[] { },
        IncludeOn = new[] { typeof(HomePage) })]
    public class ConfirmationPage : BasePageData
    {
    }
}
