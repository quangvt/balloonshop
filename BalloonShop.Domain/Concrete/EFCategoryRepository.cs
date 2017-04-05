using BalloonShop.Domain.Abstract;
using System.Collections.Generic;
using BalloonShop.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace BalloonShop.Domain.Concrete
{
    //public class EFCategoryRepository : IRepository<Category>
    public class EFCategoryRepository : ICategoryRepository
    {
        AppDbContext context = new AppDbContext();

        public IEnumerable<Category> list
        {
            get {
                return context.Category.Include(p => p.Department); // Eagerly Loading
                //return context.Category.Include(nameof(Department)); // Eagerly Loading
                //return context.Category; // Lazy Loading
            }
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

        public IEnumerable<Department> GetDepartments()
        {
            var departments = 
                from d in context.Department
                orderby d.Name
                select d;
            return departments;
        }
    }
}
