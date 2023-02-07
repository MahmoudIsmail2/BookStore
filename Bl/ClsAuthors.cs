using BookStore.Data;
using BookStore.Domains;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Bl
{
    public interface IClsAuthors
    {
        public List<TbAuthors> GetAll();
        public bool Save(TbAuthors Author);
        public TbAuthors GetById(int id);
        public bool Delete(int id);
    }
    public class ClsAuthors : IClsAuthors
    {
        ApplicationDbContext context;
        public ClsAuthors(ApplicationDbContext _context)
        {
            context = _context;
        }
        public List<TbAuthors> GetAll()
        {
            try
            {
                var lstAuthors = context.TbAuthors.AsNoTracking().ToList();
                return lstAuthors;
            }
            catch (Exception ex)
            {
                return new List<TbAuthors>();
            }


        }
        public TbAuthors GetById(int id)
        {
            try
            {
                var Author = context.TbAuthors.SingleOrDefault(a => a.AuthorId == id);
                return Author;
            }
            catch (Exception ex)
            {
                return new TbAuthors();
            }


        }
        public bool Save(TbAuthors Author)
        {
            try
            {
                if (Author.AuthorId == 0)
                    context.TbAuthors.Add(Author);
                else
                {
                    Author.LastUpdatedOn = DateTime.Now;
                    context.TbAuthors.Update(Author);

                }
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var Author = GetById(id);
                Author.IsDeleted = true;
                Author.LastUpdatedOn = DateTime.Now;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
