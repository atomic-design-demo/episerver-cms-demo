using System.Collections.Generic;
using AtomicDesignDemo.Features.Category.Models;
using AtomicDesignDemo.Features.Product.ViewModels;
using AtomicDesignDemo.Models.Interfaces;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Features.Category.ViewModels
{
    public class CategoryPageViewModel : PageViewModel<CategoryPage>, IHasPagination
    {
        public ProductListViewModel StackedBlockSection { get; set; }
        public IEnumerable<PaginationItemModel> PaginationList { get; set; }
    }
}
