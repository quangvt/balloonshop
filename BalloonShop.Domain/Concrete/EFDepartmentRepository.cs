using BalloonShop.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonShop.Domain.Entities;

namespace BalloonShop.Domain.Concrete
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        AppDbContext context = new AppDbContext();

        public IEnumerable<Department> Departments
        {
            get { return context.Department; }
        }

        public Department Delete(int departmentId)
        {
            Department dbEntry = context.Department.Find(departmentId);
            if (dbEntry != null)
            {
                context.Department.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Save(Department dept)
        {
            if(dept.DepartmentId == 0)
            {
                context.Department.Add(dept);
            }
            else
            {
                Department dbEntry = context.Department.Find(dept.DepartmentId);
                if (dbEntry != null)
                {
                    dbEntry.Name = dept.Name;
                    dbEntry.Description = dept.Description;
                }
            }
            context.SaveChanges();
        }
    }
}
