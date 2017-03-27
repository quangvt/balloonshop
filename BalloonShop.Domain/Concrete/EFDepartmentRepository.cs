using BalloonShop.Domain.Abstract;
using System.Collections.Generic;
using BalloonShop.Domain.Entities;
using System.Data.Entity;

namespace BalloonShop.Domain.Concrete
{
    public class EFDepartmentRepository : IRepository<Department>
    {
        AppDbContext context = new AppDbContext();

        public IEnumerable<Department> list
        {
            get { return context.Department; }
            //get { return context.Department.Include(t => t.Categories); }
        }

        public Department Delete(int id)
        {
            Department dbEntry = context.Department.Find(id);
            if (dbEntry != null)
            {
                context.Department.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Save(Department item)
        {
            if(item.DepartmentId == 0)
            {
                context.Department.Add(item);
            }
            else
            {
                Department dbEntry = context.Department.Find(item.DepartmentId);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Description = item.Description;
                }
            }
            context.SaveChanges();
        }
    }
}
