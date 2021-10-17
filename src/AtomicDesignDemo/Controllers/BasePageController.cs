using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Features.Home.Models;
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
            model.CurrentPage = currentPage;
            model.Page = currentPage;
            model.Layout = new LayoutModel
            {
            };
            model.Company = new CompanyInfo { Name = "Soul Soles" };
            model.FooterLogo = new Logo {StyleModifier = "c-logo--light" };

            var homePage = currentPage is HomePage hp ? hp : ContentLoader.Get<HomePage>(ContentReference.StartPage);
            if (homePage.NavItems != null)
            {
                model.NavItems = homePage.NavItems.Select(x => new NavItem { Label = x.Text, Url = x.Href });
            }

            if (homePage.FooterNavItems != null)
            {
                model.FooterNav = homePage.FooterNavItems.Select(x => new NavItem {Label = x.Text, Url = x.Href});
            }

            return model;
        }
    }
}
