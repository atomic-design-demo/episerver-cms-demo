using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Models;
using AtomicDesignDemo.Models.ViewModels;
using EPiServer.Web.Mvc;

namespace AtomicDesignDemo.Controllers
{
    public abstract class BasePageController<TPage, TViewModel>
        : PageController<TPage>
        where TPage : BasePageData
        where TViewModel : PageViewModel<TPage>, new()
    {
        protected TViewModel Model;
        
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
            model.Layout = new LayoutModel
            {
            };

            return model;
        }
    }
}