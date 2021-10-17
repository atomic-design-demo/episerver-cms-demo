using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Models;
using EPiServer;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace AtomicDesignDemo.Features.Hero.Models
{
    [ContentType(
        GUID = "d6d7bdec-542d-482e-946c-d41d47f865d2",
        DisplayName = "Hero Block",
        GroupName = Global.GroupNames.Specialized)]
    public class HeroBlock : BaseBlockData
    {
        [Display(
            Name = "Heading",
            Order = 10)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(
            Name = "URL",
            Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual Url Url { get; set; }

        [Display(
            Name = "Alternative text",
            Order = 30)]
        public virtual string AlternativeText { get; set; }
    }
}
