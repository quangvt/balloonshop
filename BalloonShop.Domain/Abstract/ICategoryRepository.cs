using BalloonShop.Domain.Entities;
using System.Collections.Generic;

namespace BalloonShop.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> list { get; }
        void Save(Category item);
        Category Delete(int id);
    }
}
