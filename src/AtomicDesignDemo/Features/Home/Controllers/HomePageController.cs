using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AtomicDesignDemo.Controllers;
using AtomicDesignDemo.Extensions;
using AtomicDesignDemo.Features.Hero.Models;
using AtomicDesignDemo.Features.Hero.ViewModels;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Features.Home.ViewModels;
using AtomicDesignDemo.Features.Promotion.Models;
using AtomicDesignDemo.Features.Promotion.ViewModels;
using EPiServer;
using EPiServer.Core;

namespace AtomicDesignDemo.Features.Home.Controllers
{
    public class HomePageController
        : BasePageController<HomePage, HomePageViewModel>
    {
        public ActionResult Index(HomePage currentPage)
        {
            if (!ContentReference.IsNullOrEmpty(currentPage.Hero))
            {
                var heroBlock = ContentLoader.Get<HeroBlock>(currentPage.Hero);
                Model.Hero = new HeroBlockViewModel
                {
                    Src = heroBlock.Url.ToFriendlyUrl(),
                    Alt = heroBlock.AlternativeText,
                    Heading = heroBlock.Heading
                };
            }

            Model.PromoBlock = currentPage.Promotions
                .GetElementsOfType<PromotionBlock>()
                ?.Select(x => new PromotionBlockViewModel
                {
                    Heading = x.Heading,
                    Description = x.Description?.ToHtmlString(),
                    Src = x.Url.ToFriendlyUrl(),
                    Alt = x.AlternativeText,
                    StyleModifier = GetPromotionModifier(x)
                });

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

        public HomePageController(IContentLoader contentLoader) : base(contentLoader)
        {
        }
    }
}
