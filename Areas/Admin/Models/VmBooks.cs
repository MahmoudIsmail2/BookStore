using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Models
{
    public class VmBooks
    {
       
        public int BookId { get; set; }
       
        public string BookTitle { get; set; }
      
        public string Hall { get; set; }
        
        public string Descreption { get; set; }
       
        public string ImageUrl { get; set; }
      
        public bool IsAvaliableForRental { get; set; }
       
        public string Publisher { get; set; }
        public DateTime PublishingDate { get; set; }
       
        public string Author { get; set; }

       
        public string Category { get; set; }
      
        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
