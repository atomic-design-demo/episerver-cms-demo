using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Button.ViewModels;
using AtomicDesignDemo.Features.Cart.Models;
using AtomicDesignDemo.Features.Checkout.ViewModels;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Features.ReviewPage.ViewModels;
using AtomicDesignDemo.Models.ViewModels;
using EPiServer;
using EPiServer.Core;

namespace AtomicDesignDemo.Features.ReviewPage.Controllers
{
    public class ReviewPageController : BasePageController<Models.ReviewPage, ReviewPageViewModel>
    {
        public ReviewPageController(IContentLoader contentLoader) : base(contentLoader)
        {
        }

        public override ActionResult Index(Models.ReviewPage currentPage)
        {
            Model.ProgressTracker = new ProgressTrackerModel
            {
                Items = new[]
                {
                    new ProgressTrackerItemModel {Number = "1", Label = "Shipping Information"},
                    new ProgressTrackerItemModel {Number = "2", Label = "Billing Information"},
                    new ProgressTrackerItemModel
                    {
                        Number = "3", Label = "Review Order", StyleModifier = "is-current"
                    },
                    new ProgressTrackerItemModel {Number = "4", Label = "Confirmation"}
                }
            };

            if (!ContentReference.IsNullOrEmpty(currentPage.CartPage))
            {
                var cartPage = ContentLoader.Get<CartPage>(currentPage.CartPage);
                var definitionGroups = cartPage.CartItems
                    .GetElementsOfType<ProductPage>()
                    ?.Select(x => new CheckoutDefinitionGroupModel
                    {
                        DefinitionList = new[]{
                            new CheckoutDefinitionListModel{
                                Items = new List<CheckoutDefinitionItemModel>
                                {
                                    new CheckoutDefinitionItemModel {Term = "Item", Description = x.Title},
                                    new CheckoutDefinitionItemModel {Term = "Quantity", Description = "1"},
                                    new CheckoutDefinitionItemModel {Term = "Price", Description = x.Price}
                                }}}
                    });

                Model.DefinitionListSection = new DefinitionListSectionModel
                {
                    StyleModifier = "c-definition-list-list--lined",
                    DefinitionItems = definitionGroups
                };

                Model.TotalPrice = new PriceSectionModel { Label = "Total", Number = "$240" };
            }

            if (!ContentReference.IsNullOrEmpty(currentPage.ConfirmationPage))
            {
                Model.ButtonGroup = new List<ButtonBlockViewModel>
                {
                    new ButtonBlockViewModel
                    {
                        ButtonTag = false,
                        LinkTag = true,
                        Url = currentPage.ConfirmationPage.ToFriendlyUrl(),
                        ButtonText = "Submit Order"
                    }
                };
            }

            Model.HtmlText = currentPage.HtmlText?.ToHtmlString();

            return View(Model);
        }
    }
}
