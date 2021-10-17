using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Models.Interfaces
{
    public interface IPageViewModel<out TPage>
        where TPage : BasePageData
    {
        TPage CurrentPage { get; }
        LayoutModel Layout { get; }
    }
}