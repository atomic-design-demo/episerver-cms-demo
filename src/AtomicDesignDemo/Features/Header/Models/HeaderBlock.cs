using AtomicDesignDemo.Models;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Features.Header.Models
{
    [ContentType(
        GUID = "543e226d-2bdf-4709-b780-be27af4f3042",
        DisplayName = "Home Page",
        GroupName = Global.GroupNames.Specialized)]
    public class HeaderBlock : BaseBlockData
    {
    }
}
