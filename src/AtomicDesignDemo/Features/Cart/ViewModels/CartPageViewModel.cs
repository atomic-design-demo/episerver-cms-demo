using System.Collections.Generic;
using AtomicDesignDemo.Features.Button.ViewModels;
using AtomicDesignDemo.Features.Cart.Models;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Cart.ViewModels
{
    public class CartPageViewModel : PageViewModel<CartPage>
    {
        public ProgressTrackerModel ProgressTracker { get; set; }
        public IEnumerable<CartLineItemModel> StripeList { get; set; }
        public PriceSectionModel TotalPrice { get; set; }
        public ButtonBlockViewModel CheckOutButton { get; set; }
    }

    public class CartLineItemModel
    {
        public string Url { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Headline { get; set; }
        public PriceSectionModel CartPrice { get; set; }
        public CartLineItemFieldModel StripeField { get; set; }
    }

    public class CartLineItemFieldModel
    {
        public string StyleModifier { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
