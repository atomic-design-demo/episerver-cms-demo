using System.Collections.Generic;
using AtomicDesignDemo.Features.Home.Models;
using AtomicDesignDemo.Features.Promotion.ViewModels;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Home.ViewModels
{
    public class HomePageViewModel : PageViewModel<HomePage>
    {
        public IEnumerable<PromotionBlockViewModel> PromoBlock { get; set; }
    }
}
