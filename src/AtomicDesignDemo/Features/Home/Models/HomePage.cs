using AtomicDesignDemo.Models;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Features.Home.Models
{
    [ContentType(
        GUID = "9e643bbc-e24e-40fe-bad9-d36181686ac0",
        DisplayName = "Home Page",
        GroupName = Global.GroupNames.Specialized)]
    public class HomePage : BasePageData
    {
    }
}