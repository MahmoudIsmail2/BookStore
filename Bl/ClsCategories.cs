using BookStore.Data;
using BookStore.Domains;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Bl
{
    public interface IClsCategories
    {
        public List<TbCategories> GetAll();
        public bool Save(TbCategories category);
        public TbCategories GetById(int id);
        public bool Delete(int id);
    }
    public class ClsCategories:IClsCategories
    {
        ApplicationDbContext context;
        public ClsCategories(ApplicationDbContext _context)
        {
            context = _context; 
        }
        public List<TbCategories> GetAll()
        {
            try
            {
                var lstcategories = context.TbCategories.AsNoTracking().ToList();
                return lstcategories;
            }
            catch(Exception ex)
            {
                return new List<TbCategories>();
            }
           

        }
        public TbCategories GetById(int id)
        {
            try
            {
                var category = context.TbCategories.SingleOrDefault(a=>a.CategoryId==id);
                return category;
            }
            catch (Exception ex)
            {
                return new TbCategories();
            }


        }
        public bool Save(TbCategories category)
        {
            try
            {
                if(category.CategoryId==0)
                    context.TbCategories.Add(category);
                else
                {
                    category.LastUpdatedOn = DateTime.Now;
                    context.TbCategories.Update(category);
                }
                context.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var category = GetById(id);
                category.IsDeleted = true;
                category.LastUpdatedOn = DateTime.Now;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
      
        }

    }
}
