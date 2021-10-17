using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Features.Home.ViewModels;
using AtomicDesignDemo.Features.Promotion.Models;
using AtomicDesignDemo.Features.Promotion.ViewModels;
using EPiServer;

namespace AtomicDesignDemo.Features.Home.Controllers
{
    public class HomePageController
        : BasePageController<HomePage, HomePageViewModel>
    {
        public HomePageController(IContentLoader contentLoader) : base(contentLoader)
        {
        }

        public override ActionResult Index(HomePage currentPage)
        {
            var promotionBlocks = currentPage.Promotions
                .GetElementsOfType<PromotionBlock>()
                ?.Select(x => new PromotionBlockViewModel
                {
                    Heading = x.Heading,
                    Description = x.Description?.ToHtmlString(),
                    Src = x.Image.ToFriendlyUrl(),
                    Alt = x.AlternativeText,
                    StyleModifier = GetPromotionModifier(x),
                    PromoBlockLink = new PromotionBlockLink { Url = x.Url.ToFriendlyUrl() }
                })
                .ToList();

            Model.PromoBlock = promotionBlocks;

            return View(Model);
        }

        private string GetPromotionModifier(PromotionBlock promotionBlock)
        {
            var modifiers = new List<string>();
            if (promotionBlock.HeadingAlignment == PromotionHeadingAlignment.Right)
            {
                modifiers.Add("c-promo-block--right");
            }

            if (promotionBlock.Margin == PromotionMargin.BottomLarge)
            {
                modifiers.Add("u-margin-bottom-large");
            }

            return string.Join(" ", modifiers);
        }
    }
}
