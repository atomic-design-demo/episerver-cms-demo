using System.Web.Mvc;
using AtomicDesignDemo.Features.Header.Models;
using AtomicDesignDemo.Features.Header.ViewModels;
using EPiServer.Web.Mvc;

namespace AtomicDesignDemo.Features.Header.Controllers
{
    public class HeaderBlockController : BlockController<HeaderBlock>
    {
        public override ActionResult Index(HeaderBlock currentContent)
        {
            var model = new HeaderBlockViewModel();
            return View(model);
        }
    }
}