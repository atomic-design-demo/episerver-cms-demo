using System;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Features.ReviewPage.ViewModels;
using EPiServer;

namespace AtomicDesignDemo.Features.ReviewPage.Controllers
{
    public class ReviewPageController : BasePageController<Models.ReviewPage, ReviewPageViewModel>
    {
        public ReviewPageController(IContentLoader contentLoader) : base(contentLoader)
        {
        }

        public override ActionResult Index(Models.ReviewPage currentPage)
        {
            return View(Model);
        }
    }
}
