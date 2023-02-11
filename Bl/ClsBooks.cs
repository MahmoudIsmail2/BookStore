using BookStore.Data;

namespace BookStore.Bl
{
    public interface IClsBooks
    {
        public bool Save(TbBooks book);
        public TbBooks GetById(int id);
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
    }
}
