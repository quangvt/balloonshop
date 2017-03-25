using BalloonShop.Domain.Entities;
using System.Collections.Generic;

namespace BalloonShop.Domain.Abstract
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> list { get; }
        void Save(Department item);
        Department Delete(int id);
    }
}
