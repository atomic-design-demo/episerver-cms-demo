using System.Collections.Generic;
using AtomicDesignDemo.Models.ViewModels;

namespace AtomicDesignDemo.Models.Interfaces
{
    public interface IHasPagination
    {
        IEnumerable<PaginationItemModel> PaginationList { get; set; }
    }
}
