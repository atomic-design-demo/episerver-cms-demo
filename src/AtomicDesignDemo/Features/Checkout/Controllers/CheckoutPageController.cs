using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Checkout.Models;
using AtomicDesignDemo.Features.Checkout.ViewModels;
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
                            }
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
                                    TextField = new CheckOutFormFieldInnerModel { Label = choiceItem.Caption }
                                });
                            }
                        }
                    }
                }
            }

            return View(Model);
        }
    }
}
