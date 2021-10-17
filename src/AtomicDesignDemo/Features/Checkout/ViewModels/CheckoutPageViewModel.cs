using System.Collections.Generic;
using AtomicDesignDemo.Features.Checkout.Models;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Checkout.ViewModels
{
    public class CheckoutPageViewModel : PageViewModel<CheckOutPage>
    {
        public CheckOutFormModel FormFields { get; set; }
    }

    public class CheckOutFormModel
    {
        public IEnumerable<CheckOutFormFieldModel> Items { get; set; }
    }

    public class CheckOutFormFieldModel
    {
        public CheckOutFormFieldInnerModel TextField { get; set; }
        public CheckOutFormFieldInnerModel InlineCheckbox { get; set; }
    }

    public class CheckOutFormFieldInnerModel
    {
        public string StyleModifier { get; set; }
        public string Label { get; set; }
    }
}
