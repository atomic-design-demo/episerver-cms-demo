using AtomicDesignDemo.Models.Interfaces;

namespace AtomicDesignDemo.Models.ViewModels
{
    public class PageViewModel<TPage>
        : IPageViewModel<TPage> where TPage : BasePageData
    {
        public TPage CurrentPage { get; set; }
        public LayoutModel Layout { get; set; }
    }
}