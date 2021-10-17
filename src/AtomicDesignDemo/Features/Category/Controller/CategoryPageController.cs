using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Features.Category.Models;
using AtomicDesignDemo.Features.Category.ViewModels;
using EPiServer;

namespace AtomicDesignDemo.Features.Category.Controller
{
    public class CategoryPageController : BasePageController<CategoryPage, CategoryPageViewModel>
    {
        public CategoryPageController(IContentLoader contentLoader)
            : base(contentLoader)
        {
        }

        public override ActionResult Index(CategoryPage currentPage)
        {
            return View(Model);
        }
    }
}
