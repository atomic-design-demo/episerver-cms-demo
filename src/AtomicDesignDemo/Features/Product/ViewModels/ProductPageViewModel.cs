using System.Collections.Generic;
using AtomicDesignDemo.Features.Image.ViewModels;
using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Models.Interfaces;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Product.ViewModels
{
    public class ProductPageViewModel : PageViewModel<ProductPage>, IHasPagination
    {
        public IEnumerable<PaginationItemModel> PaginationList { get; set; }
        public ImageFileViewModel FeatureImage { get; set; }
        public PriceSectionModel PriceSection { get; set; }
        public string HtmlText { get; set; }
        public CheckoutFormModel CheckoutForm { get; set; }
        public ProductListViewModel StackedBlockSection { get; set; }
    }
}
