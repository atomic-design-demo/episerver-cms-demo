using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Models;
using EPiServer;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo.Features.Button.Models
{
    [ContentType(
        GUID = "d2b4b27e-db1a-41ea-8a34-17ef32f53cda",
        DisplayName = "Button Block",
        GroupName = Global.GroupNames.Specialized)]
    public class ButtonBlock : BaseBlockData
    {
        [Display(
            Name = "URL",
            Order = 10)]
        [CultureSpecific]
        public virtual Url Url { get; set; }

        [Display(
            Name = "Text",
            Order = 20)]
        [CultureSpecific]
        public virtual string Text { get; set; }
    }
}
