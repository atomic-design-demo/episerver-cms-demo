using System.Collections.Generic;
using AtomicDesignDemo.Features.Button.ViewModels;

namespace AtomicDesignDemo.Models.ViewModels
{
    public class CheckoutFormModel
    {
        public IEnumerable<ButtonBlockViewModel> ButtonGroup { get; set; }
    }
}
