using System.Collections.Generic;
using AtomicDesignDemo.Features.Button.ViewModels;
using AtomicDesignDemo.Features.Checkout.Models;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Checkout.ViewModels
{
    public class CheckoutPageViewModel : PageViewModel<CheckOutPage>
    {
        public ProgressTrackerModel ProgressTracker { get; set; }
        public CheckOutFormModel FormFields { get; set; }
        public IEnumerable<ButtonBlockViewModel> ButtonGroup { get; set; }
        public DefinitionListSectionModel DefinitionListSection { get; set; }
        public PriceSectionModel TotalPrice { get; set; }
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
        public string Value { get; set; }
    }

    public class DefinitionListSectionModel
    {
        public string StyleModifier { get; set; }
        public IEnumerable<CheckoutDefinitionGroupModel> DefinitionItems { get; set; }
    }

    public class CheckoutDefinitionGroupModel
    {
        public IEnumerable<CheckoutDefinitionListModel> DefinitionList { get; set; }
    }

    public class CheckoutDefinitionListModel
    {
        public IEnumerable<CheckoutDefinitionItemModel> Items { get; set; }
    }

    public class CheckoutDefinitionItemModel
    {
        public string Term { get; set; }
        public string Description { get; set; }
    }
}
