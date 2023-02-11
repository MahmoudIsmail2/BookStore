using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Models
{
    public class VmBooks
    {
        public TbBooks Books { get; set; }
        public List<TbAuthors> Authors { get; set; }
        public List<TbCategories> Categories { get; set; }
    }
}
