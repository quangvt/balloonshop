using BalloonShop.Domain.Entities;
using System.Collections.Generic;

namespace BalloonShop.Domain.Abstract
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> Departments { get; }
        void Save(Department dept);
        Department Delete(int departmentId);
    }
}
