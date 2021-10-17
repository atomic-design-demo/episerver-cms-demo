using System.Collections.Generic;
using AtomicDesignDemo.Features.Hero.ViewModels;
using AtomicDesignDemo.Models.Interfaces;

namespace AtomicDesignDemo.Models.ViewModels
{
    public class PageViewModel<TPage>
        : IPageViewModel<TPage> where TPage : BasePageData
    {
        public string HomePageUrl { get; set; }
        public HeroBlockViewModel Hero { get; set; }
        public TPage CurrentPage { get; set; }
        public PageModel Page { get; set; }
        public LayoutModel Layout { get; set; }
        public string HeaderStyleModifier { get; set; }
        public IEnumerable<NavItem> NavItems { get; set; }
        public IEnumerable<NavItem> FooterNav { get; set; }
        public CompanyInfo Company { get; set; }
        public Logo FooterLogo { get; set; }
    }

    public class PageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
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
