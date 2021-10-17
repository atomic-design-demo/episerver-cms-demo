using AtomicDesignDemo.Features.Confirmation.Models;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Confirmation.ViewModels
{
    public class ConfirmationPageViewModel : PageViewModel<ConfirmationPage>
    {
        public ProgressTrackerModel ProgressTracker { get; set; }
        public string HtmlText { get; set; }
    }
}
