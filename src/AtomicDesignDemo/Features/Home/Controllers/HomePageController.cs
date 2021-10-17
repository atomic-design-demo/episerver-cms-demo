using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Features.Home.ViewModels;

namespace AtomicDesignDemo.Features.Home.Controllers
{
    public class HomePageController
        : BasePageController<HomePage, HomePageViewModel>
    {
        public ActionResult Index(HomePage currentPage)
        {
            return View(Model);
        }
    }
}