using System.Collections.Generic;
using AtomicDesignDemo.Features.Button.ViewModels;
using AtomicDesignDemo.Features.Checkout.ViewModels;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.ReviewPage.ViewModels
{
    public class ReviewPageViewModel : PageViewModel<Models.ReviewPage>
    {
        public ProgressTrackerModel ProgressTracker { get; set; }
        public IEnumerable<ButtonBlockViewModel> ButtonGroup { get; set; }
        public DefinitionListSectionModel DefinitionListSection { get; set; }
        public PriceSectionModel TotalPrice { get; set; }
    }
}
