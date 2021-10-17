using System.Collections.Generic;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Models.Interfaces
{
    public interface IPageViewModel<out TPage>
        where TPage : BasePageData
    {
        TPage CurrentPage { get; }
        PageModel Page { get; }
        LayoutModel Layout { get; }
        string HeaderStyleModifier { get; }
        IEnumerable<NavItem> NavItems { get; }
    }
}
