using System.Web;

namespace AtomicDesignDemo.Models.ViewModels
{
    public class LayoutModel
    {
        public IHtmlString LogotypeLinkUrl { get; set; }
        public bool HideHeader { get; set; }
        public bool HideFooter { get; set; }

        public bool IsInReadonlyMode { get; set; }
    }
}