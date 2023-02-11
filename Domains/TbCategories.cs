using Microsoft.AspNetCore.Mvc;

namespace BookStore.Domains
{
    public class TbCategories:BaseModel
    {
        public TbCategories()
        {
             Books=new HashSet<TbBooks>();   
        }
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage =" You Should Enter Category Name")]
        [MaxLength(50,ErrorMessage ="Category Name Must Be Less Than 50 Char")]
        [Remote ("AllowCategory", "Categories","Admin",ErrorMessage ="This Category Aleardy Exist")]
        public string CategoryName { get; set; }
        public ICollection<TbBooks> Books { get; set; }

    }
}
