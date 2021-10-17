using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Button.ViewModels;
using AtomicDesignDemo.Features.Cart.Models;
using AtomicDesignDemo.Features.Checkout.Models;
using AtomicDesignDemo.Features.Checkout.ViewModels;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Forms.Implementation.Elements;
// ReSharper disable SuspiciousTypeConversion.Global

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
            Model.ProgressTracker = new ProgressTrackerModel
            {
                Items = new[]
                {
                    new ProgressTrackerItemModel {Number = "1", Label = "Shipping Information"},
                    new ProgressTrackerItemModel {Number = "2", Label = "Billing Information", StyleModifier = "is-current"},
                    new ProgressTrackerItemModel {Number = "3", Label = "Review Order"},
                    new ProgressTrackerItemModel {Number = "4", Label = "Confirmation"}
                }
            };

            var form = currentPage.CheckoutForm
                .GetElementsOfType<FormContainerBlock>()
                ?.FirstOrDefault();

            if (form != null)
            {
                var items = new List<CheckOutFormFieldModel>();
                Model.FormFields = new CheckOutFormModel
                {
                    Items = items
                };

                var formFields = form.ElementsArea
                    .GetElementsOfType<IContent>()
                    .ToList();

                foreach (var formField in formFields)
                {
                    if (formField is TextboxElementBlock textBox)
                    {
                        items.Add(new CheckOutFormFieldModel
                        {
                            TextField = new CheckOutFormFieldInnerModel
                            {
                                Label = textBox.Label
                            },
                            InlineCheckbox = null
                        });
                    }
                    if (formField is ChoiceElementBlock choice)
                    {
                        if (choice.Items != null)
                        {
                            foreach (var choiceItem in choice.Items)
                            {
                                items.Add(new CheckOutFormFieldModel
                                {
                                    TextField = null,
                                    InlineCheckbox = new CheckOutFormFieldInnerModel { Label = choice.Label, StyleModifier = "u-margin-bottom-large" }
                                });
                            }
                        }
                    }
                }
            }

            if (!ContentReference.IsNullOrEmpty(currentPage.CartPage))
            {
                var cartPage = ContentLoader.Get<CartPage>(currentPage.CartPage);
                var cartItems = cartPage.CartItems
                    .GetElementsOfType<ProductPage>()
                    ?.ToList();
                var definitionGroups = cartItems
                    ?.Select(x => new CheckoutDefinitionGroupModel
                    {
                        DefinitionList = new[]{
                            new CheckoutDefinitionListModel{
                                Items = new List<CheckoutDefinitionItemModel>
                                {
                                    new CheckoutDefinitionItemModel {Term = "Item", Description = x.Title},
                                    new CheckoutDefinitionItemModel {Term = "Quantity", Description = "1"},
                                    new CheckoutDefinitionItemModel {Term = "Price", Description = $"${x.Price}"}
                                }}}
                    });

                Model.DefinitionListSection = new DefinitionListSectionModel
                {
                    StyleModifier = "c-definition-list-list--lined",
                    DefinitionItems = definitionGroups
                };

                Model.TotalPrice = new PriceSectionModel { Label = "Total", Number = $"${cartItems?.Sum(x => x.Price)}" };
            }

            if (!ContentReference.IsNullOrEmpty(currentPage.ReviewPage))
            {
                Model.ButtonGroup = new List<ButtonBlockViewModel>
                {
                    new ButtonBlockViewModel
                    {
                        ButtonTag = false,
                        LinkTag = true,
                        Url = currentPage.ReviewPage.ToFriendlyUrl(),
                        ButtonText = "Continue to Billing"
                    }
                };
            }

            return View(Model);
        }
    }
}
