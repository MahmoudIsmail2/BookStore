using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Domains
{
    [Index(nameof(AuthorName),IsUnique =true)]
    public class TbAuthors:BaseModel
    {
        [Key]
        public int AuthorId { get; set; }
        [Remote("AllowAuthor", "Authors", "Admin", ErrorMessage = "This Author Aleardy Exist")]
        [MaxLength(50, ErrorMessage = "Author Name Must Be Short Than 50 char")]
        [Required(ErrorMessage = "Author Name Is Requird")]
        public string AuthorName { get; set; } 

    }
}
