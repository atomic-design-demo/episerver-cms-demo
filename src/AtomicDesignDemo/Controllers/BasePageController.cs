using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Category.Models;
using AtomicDesignDemo.Features.Hero.Models;
using AtomicDesignDemo.Features.Hero.ViewModels;
using AtomicDesignDemo.Models;
using AtomicDesignDemo.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;

namespace AtomicDesignDemo.Controllers
{
    public abstract class BasePageController<TPage, TViewModel>
        : PageController<TPage>
        where TPage : BasePageData
        where TViewModel : PageViewModel<TPage>, new()
    {
        protected readonly IContentLoader ContentLoader;
        protected TViewModel Model;

        protected BasePageController(IContentLoader contentLoader)
        {
            ContentLoader = contentLoader;
        }

        public abstract ActionResult Index(TPage currentPage);

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.ActionParameters.Any())
            {
                var currentPage = filterContext.ActionParameters.FirstOrDefault(ap => ap.Value is TPage).Value as TPage;

                Model = filterContext.ActionParameters.FirstOrDefault(ap => ap.Value is TViewModel).Value as TViewModel;

                InitializeModel(currentPage, Model);
            }
        }

        private void InitializeModel(TPage currentPage, TViewModel model)
        {
            Model = PopulateViewModel(currentPage, model);
        }

        private TViewModel PopulateViewModel(TPage currentPage, TViewModel model)
        {
            model ??= new TViewModel();
            model.HomePageUrl = ContentReference.StartPage.ToFriendlyUrl();
            model.CurrentPage = currentPage;
            model.Page = new PageModel
            {
                Title = currentPage.Title,
                Description = currentPage.Description?.ToHtmlString()
            };
            model.Layout = new LayoutModel
            {
            };
            model.Company = new CompanyInfo { Name = "Soul Soles" };
            model.FooterLogo = new Logo { StyleModifier = "c-logo--light" };

            var navItems = ContentLoader
                .GetChildren<BasePageData>(ContentReference.StartPage)
                .OrderBy(x => x.SortIndex)
                .Select(x => new NavItem { Label = x.Name, Url = x.ContentLink.ToFriendlyUrl() })
                .ToList();
            model.NavItems = navItems;
            model.FooterNav = navItems;

            if (!ContentReference.IsNullOrEmpty(currentPage.Hero))
            {
                var heroBlock = ContentLoader.Get<HeroBlock>(currentPage.Hero);

                if (heroBlock != null)
                {
                    model.Hero = new HeroBlockViewModel
                    {
                        Src = heroBlock.Image.ToFriendlyUrl(),
                        Alt = heroBlock.AlternativeText,
                        Heading = heroBlock.Heading,
                        Url = heroBlock.Url.ToFriendlyUrl()
                    };
                }
            }

            return model;
        }
    }
}
