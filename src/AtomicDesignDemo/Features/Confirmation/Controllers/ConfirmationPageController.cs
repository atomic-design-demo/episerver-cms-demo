using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Features.Confirmation.Models;
using AtomicDesignDemo.Features.Confirmation.ViewModels;
using AtomicDesignDemo.Models.ViewModels;
using EPiServer;

namespace AtomicDesignDemo.Features.Confirmation.Controllers
{
    public class ConfirmationPageController : BasePageController<ConfirmationPage, ConfirmationPageViewModel>
    {
        public ConfirmationPageController(IContentLoader contentLoader) : base(contentLoader)
        {
        }

        public override ActionResult Index(ConfirmationPage currentPage)
        {
            Model.ProgressTracker = new ProgressTrackerModel
            {
                Items = new[]
                {
                    new ProgressTrackerItemModel {Number = "1", Label = "Shipping Information"},
                    new ProgressTrackerItemModel {Number = "2", Label = "Billing Information"},
                    new ProgressTrackerItemModel {Number = "3", Label = "Review Order"},
                    new ProgressTrackerItemModel {Number = "4", Label = "Confirmation", StyleModifier = "is-current"}
                }
            };
            return View(Model);
        }
    }
}
