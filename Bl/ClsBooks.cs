using BookStore.Areas.Admin.Models;
using BookStore.Data;
using System.Net;

namespace BookStore.Bl
{
    public interface IClsBooks
    {
        public bool Save(TbBooks book);
        public TbBooks GetById(int id);
        public IEnumerable< VmBooks> GetBookDetails(int bookid);
    }
    public class ClsBooks:IClsBooks
    {
        ApplicationDbContext context;
        public ClsBooks(ApplicationDbContext _context)
        {
            context = _context;
        }
        public bool Save(TbBooks book)
        {
            try
            {
                if (book.BookId == 0)
                    context.TbBooks.Add(book);
                else
                {
                    book.LastUpdatedOn = DateTime.Now;  
                    context.TbBooks.Update(book);
                }

                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public TbBooks GetById(int id)
        {
            try
            {
               
                  return context.TbBooks.Find(id);

            }
            catch(Exception ex)
            {
                return new TbBooks();

            }
        }

        public IEnumerable< VmBooks> GetBookDetails(int bookid)
        {
            var book = from b in context.TbBooks.Where(b => b.BookId == bookid)
                       join c in context.TbCategories
                       on b.CategoryId equals c.CategoryId
                       join a in context.TbAuthors on b.AuthorId equals a.AuthorId
                       select new VmBooks
                       {
                           BookId=b.BookId,
                           BookTitle = b.BookTitle,
                           Publisher = b.Publisher,
                           PublishingDate = b.PublishingDate,
                           IsAvaliableForRental = b.IsAvaliableForRental,
                           Author = a.AuthorName,
                           Category = c.CategoryName,
                           ImageUrl = b.ImageUrl,
                           IsDeleted = b.IsDeleted,
                           CreatedOn = b.CreatedOn,
                           Descreption = b.Descreption,

                       };

            return book;
        }
    }
}
