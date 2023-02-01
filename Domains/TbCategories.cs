using Microsoft.AspNetCore.Mvc;

namespace BookStore.Domains
{
    public class TbCategories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage =" You Should Enter Category Name")]
        [MaxLength(50,ErrorMessage ="Category Name Must Be Less Than 50 Char")]
        [Remote ("AllowCategory", "Categories","Admin",ErrorMessage ="This Category Aleardy Exist")]
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedOn { get; set; } 
    }
}
