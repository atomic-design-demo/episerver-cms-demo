using System.Collections.Generic;
using AtomicDesignDemo.Features.Image.ViewModels;

namespace AtomicDesignDemo.Features.Product.ViewModels
{
    public class ProductListViewModel
    {
        public string SectionTitle { get; set; }
        public IEnumerable<ProductListItemViewModel> StackedBlockList { get; set; }
    }

    public class ProductListItemViewModel
    {
        public string Url { get; set; }
        public string StyleModifier { get; set; }
        public ImageFileViewModel StackedBlockMedia { get; set; }
        public string Headline { get; set; }
        public string Excerpt { get; set; }
        public string Label { get; set; }
    }
}
