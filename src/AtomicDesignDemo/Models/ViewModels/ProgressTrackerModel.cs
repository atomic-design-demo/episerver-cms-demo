using System.Collections.Generic;

namespace AtomicDesignDemo.Models.ViewModels
{
    public class ProgressTrackerModel
    {
        public IEnumerable<ProgressTrackerItemModel> Items { get; set; }
    }

    public class ProgressTrackerItemModel
    {
        public string Number { get; set; }
        public string Label { get; set; }
        public string StyleModifier { get; set; }
    }
}
