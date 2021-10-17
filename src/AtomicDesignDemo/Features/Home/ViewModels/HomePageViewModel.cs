using System.Collections.Generic;
using AtomicDesignDemo.Features.Hero.ViewModels;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Features.Promotion.ViewModels;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Home.ViewModels
{
    public class HomePageViewModel : PageViewModel<HomePage>
    {
        public HeroBlockViewModel Hero { get; set; }
        public IEnumerable<PromotionBlockViewModel> PromoBlock { get; set; }
    }
}
