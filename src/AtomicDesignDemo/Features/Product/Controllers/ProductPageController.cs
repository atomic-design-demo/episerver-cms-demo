using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Button.Models;
using AtomicDesignDemo.Features.Button.ViewModels;
using AtomicDesignDemo.Features.Image.ViewModels;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Features.Product.ViewModels;
using AtomicDesignDemo.Models.ViewModels;
using EPiServer;
using EPiServer.Core;

namespace AtomicDesignDemo.Features.Product.Controllers
{
    public class ProductPageController : BasePageController<ProductPage, ProductPageViewModel>
    {
        public ProductPageController(IContentLoader contentLoader)
            : base(contentLoader)
        {
        }

        public override ActionResult Index(ProductPage currentPage)
        {
            Model.HtmlText = currentPage.ProductDescription?.ToHtmlString();
            Model.PriceSection = new PriceSectionModel { Label = currentPage.Price };
            if (!ContentReference.IsNullOrEmpty(currentPage.FeaturedImage))
            {
                Model.FeatureImage = new ImageFileViewModel
                {
                    Src = currentPage.FeaturedImage.ToFriendlyUrl(),
                    Alt = currentPage.FeaturedImageAlternativeText
                };
            }

            Model.CheckoutForm = new CheckoutFormModel
            {
                ButtonGroup = currentPage.Buttons
                    .GetElementsOfType<ButtonBlock>()
                    ?.Select(x => new ButtonBlockViewModel { Url = x.Url.ToFriendlyUrl(), ButtonText = x.Text, ButtonTag = false, LinkTag = true }),
                FormFields = new FormFieldsModel
                {
                    Items = new []
                    {
                        new FormFieldItemModel
                        {
                            SelectField = new SelectFieldItemModel
                            {
                                Label = "Pick a Size",
                                SelectOptions = new []
                                {
                                    new SelectOptionModel
                                    {
                                        Value = "xs",
                                        Option = "Extra Small"
                                    },
                                    new SelectOptionModel
                                    {
                                        Value = "s",
                                        Option = "Small"
                                    },
                                    new SelectOptionModel
                                    {
                                        Value = "m",
                                        Option = "Medium"
                                    },
                                    new SelectOptionModel
                                    {
                                        Value = "l",
                                        Option = "Large"
                                    },
                                    new SelectOptionModel
                                    {
                                        Value = "xl",
                                        Option = "Extra Large"
                                    },
                                    new SelectOptionModel
                                    {
                                        Value = "xxl",
                                        Option = "Extra Large Max"
                                    },
                                }
                            }
                        }
                    }
                }
            };

            var relatedItems = currentPage.RelatedItems
                .GetElementsOfType<ProductPage>()
                ?.OrderBy(x => x.IsOnSale ? 0 : 1)
                .Select(x => new ProductListItemViewModel
                {
                    Url = x.ContentLink.ToFriendlyUrl(),
                    Excerpt = x.Excerpt,
                    Headline = x.Name,
                    Label = x.Price,
                    StackedBlockMedia = new ImageFileViewModel
                    {
                        Src = x.FeaturedImage.ToFriendlyUrl(),
                        Alt = x.FeaturedImageAlternativeText
                    },
                    StyleModifier = string.Empty,
                    OnSale = x.IsOnSale ? new PriceSectionModel
                    {
                        Badge = "Sale",
                        Price = x.RrpPrice
                    } : null
                });
            if (relatedItems != null)
            {
                Model.StackedBlockSection = new ProductListViewModel
                {
                    SectionTitle = "Related Items",
                    StackedBlockList = relatedItems
                };
            }

            return View(Model);
        }
    }
}
