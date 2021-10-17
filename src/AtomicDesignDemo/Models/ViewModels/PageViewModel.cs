using System.Collections.Generic;
using AtomicDesignDemo.Models.Interfaces;

namespace AtomicDesignDemo.Models.ViewModels
{
    public class PageViewModel<TPage>
        : IPageViewModel<TPage> where TPage : BasePageData
    {
        public TPage CurrentPage { get; set; }
        public TPage Page { get; set; }
        public LayoutModel Layout { get; set; }
        public string HeaderStyleModifier { get; set; }
        public IEnumerable<NavItem> NavItems { get; set; }
        public IEnumerable<NavItem> FooterNav { get; set; }
        public CompanyInfo Company { get; set; }
        public Logo FooterLogo { get; set; }
    }

    public class CompanyInfo
    {
        public string Name { get; set; }
    }

    public class NavItem
    {
        public string Label { get; set; }
        public string Url { get; set; }
    }

    public class Logo
    {
        public string StyleModifier { get; set; }
    }
}
