using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Button.ViewModels;
using AtomicDesignDemo.Features.Cart.Models;
using AtomicDesignDemo.Features.Cart.ViewModels;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Models.ViewModels;
using EPiServer;

namespace AtomicDesignDemo.Features.Cart.Controllers
{
    public class CartPageController
        : BasePageController<CartPage, CartPageViewModel>
    {
        public CartPageController(IContentLoader contentLoader)
            : base(contentLoader)
        {
        }

        public override ActionResult Index(CartPage currentPage)
        {
            Model.ProgressTracker = new ProgressTrackerModel
            {
                Items = new[]
                {
                    new ProgressTrackerItemModel {Number = "1", Label = "Shipping Information", StyleModifier = "is-current"},
                    new ProgressTrackerItemModel {Number = "2", Label = "Billing Information"},
                    new ProgressTrackerItemModel {Number = "3", Label = "Review Order"},
                    new ProgressTrackerItemModel {Number = "4", Label = "Confirmation"}
                }
            };

            var lineItems = currentPage.CartItems
                .GetElementsOfType<ProductPage>()
                .Select(x => new CartLineItemModel
                {
                    Url = x.ContentLink.ToFriendlyUrl(),
                    Src = x.FeaturedImage.ToFriendlyUrl(),
                    Alt = x.FeaturedImageAlternativeText,
                    StripeField =
                        new CartLineItemFieldModel
                        {
                            StyleModifier = "c-field--small",
                            Label = "Quantity",
                            Value = "1"
                        },
                    Headline = x.Title,
                    CartPrice = new PriceSectionModel { Label = "Price", Meta = x.Price }
                });

            Model.StripeList = lineItems;

            Model.TotalPrice = new PriceSectionModel { Label = "Total", Number = "$240", };

            Model.CheckOutButton = new ButtonBlockViewModel
            {
                ButtonTag = false,
                LinkTag = true,
                Url = currentPage.CheckoutPage.ToFriendlyUrl(),
                ButtonText = "Checkout"
            };

            return View(Model);
        }
    }
}
