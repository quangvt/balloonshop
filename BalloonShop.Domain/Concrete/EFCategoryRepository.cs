using BalloonShop.Domain.Abstract;
using System.Collections.Generic;
using BalloonShop.Domain.Entities;

namespace BalloonShop.Domain.Concrete
{
    public class EFCategoryRepository : IRepository<Category>
    {
        AppDbContext context = new AppDbContext();

        public IEnumerable<Category> list
        {
            get { return context.Category; }
        }

        public Category Delete(int id)
        {
            Category dbEntry = context.Category.Find(id);
            if (dbEntry != null)
            {
                context.Category.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        public void Save(Category item)
        {
            if(item.CategoryId == 0)
            {
                context.Category.Add(item);
            }
            else
            {
                Category dbEntry = context.Category.Find(item.CategoryId);
                if (dbEntry != null)
                {
                    dbEntry.CategoryId = item.CategoryId;
                    dbEntry.DepartmentId = item.DepartmentId;
                    dbEntry.Name = item.Name;
                    dbEntry.Description = item.Description;
                    dbEntry.DateAdded = item.DateAdded;
                }
            }
            context.SaveChanges();
        }
    }
}
