using System.ComponentModel.DataAnnotations;
using AtomicDesignDemo.Editor;
using AtomicDesignDemo.Models;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;

namespace AtomicDesignDemo.Features.Promotion.Models
{
    [ContentType(
        GUID = "047985f7-833e-43ab-aa56-1bf788a50c87",
        DisplayName = "Promotion Block",
        GroupName = Global.GroupNames.Specialized)]
    public class PromotionBlock : BaseBlockData
    {
        [Display(
            Name = "Heading",
            Order = 10)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(
            Name = "Description",
            Order = 15)]
        [CultureSpecific]
        public virtual XhtmlString Description { get; set; }

        [Display(
            Name = "URL",
            Order = 20)]
        [CultureSpecific]
        public virtual Url Url { get; set; }

        [Display(
            Name = "Heading Alignment",
            Order = 25)]
        [CultureSpecific]
        [EditorDescriptor(EditorDescriptorType = typeof(EnumEditorDescriptor<PromotionHeadingAlignment>))]
        [BackingType(typeof(PropertyNumber))]
        public virtual PromotionHeadingAlignment HeadingAlignment { get; set; }

        [Display(
            Name = "Margin",
            Order = 27)]
        [CultureSpecific]
        [EditorDescriptor(EditorDescriptorType = typeof(EnumEditorDescriptor<PromotionMargin>))]
        [BackingType(typeof(PropertyNumber))]
        public virtual PromotionMargin Margin { get; set; }

        [Display(
            Name = "Image",
            Order = 30)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual Url Image { get; set; }

        [Display(
            Name = "Alternative text",
            Order = 40)]
        public virtual string AlternativeText { get; set; }
    }
}
