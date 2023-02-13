using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BookStore.Domains
{
    [Index (nameof(BookTitle) ,IsUnique =true)]
    public class TbBooks:BaseModel
    {
        [Key]
        public int BookId { get; set; } 

        [Required(ErrorMessage ="Book Title Is Required")]
        [MaxLength(200,ErrorMessage ="Book Title Should Be Less Than 200 char")]
        public string BookTitle { get; set; }
        [Required(ErrorMessage = "This Field IS Required")]
        public string Hall { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        public string Descreption { get; set; }
        [Required(ErrorMessage = "This Field IS Required")]
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "This Field IS Required")]
        public bool IsAvaliableForRental { get; set; }
        [Required(ErrorMessage = "Thid Fiels IS Required")]
        public string Publisher { get; set; }

        public DateTime PublishingDate { get; set; }=DateTime.Now;
        [Required(ErrorMessage ="Author is Required")]
        public int AuthorId { get; set; }

        public TbAuthors Author { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        public int CategoryId{ get; set; }

        public TbCategories Category { get; set; }




    }
}
