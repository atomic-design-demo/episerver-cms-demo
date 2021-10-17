using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Category.Models;
using AtomicDesignDemo.Features.Category.ViewModels;
using AtomicDesignDemo.Features.Image.ViewModels;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Features.Product.ViewModels;
using AtomicDesignDemo.Models.ViewModels;
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
            var products = ContentLoader
                .GetChildren<ProductPage>(currentPage.ContentLink)
                .OrderBy(x => x.IsOnSale ? 0 : 1)
                .Select(x => new ProductListItemViewModel
                {
                    Url = x.ContentLink.ToFriendlyUrl(),
                    Excerpt = x.Excerpt,
                    Headline = x.Name,
                    Label = $"${x.Price}",
                    StackedBlockMedia =
                        new ImageFileViewModel
                        {
                            Src = x.FeaturedImage.ToFriendlyUrl(),
                            Alt = x.FeaturedImageAlternativeText
                        },
                    StyleModifier = string.Empty,
                    OnSale = x.IsOnSale ? new PriceSectionModel { Badge = "Sale", Price = $"${x.RrpPrice}" } : null
                })
                .ToList();

            Model.StackedBlockSection = new ProductListViewModel
            {
                StyleModifier = "u-margin-bottom-large",
                StackedBlockList = products
            };

            if (products.Count >= 6)
            {
                Model.PaginationList = new[]
                {
                    new PaginationItemModel {ItemModifier = "is-disabled", Number = "Prev"},
                    new PaginationItemModel {ItemModifier = "is-active", Number = "1"},
                    new PaginationItemModel {Url = "#", Number = "2"},
                    new PaginationItemModel {Url = "#", Number = "Next"}
                };
            }

            return View(Model);
        }
    }
}
