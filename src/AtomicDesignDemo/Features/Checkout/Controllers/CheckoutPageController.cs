using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Features.Checkout.Models;
using AtomicDesignDemo.Features.Checkout.ViewModels;
using EPiServer;

namespace AtomicDesignDemo.Features.Checkout.Controllers
{
    public class CheckoutPageController
        : BasePageController<CheckOutPage, CheckoutPageViewModel>
    {
        public CheckoutPageController(IContentLoader contentLoader)
            : base(contentLoader)
        {
        }

        public override ActionResult Index(CheckOutPage currentPage)
        {
            return View(Model);
        }
    }
}
