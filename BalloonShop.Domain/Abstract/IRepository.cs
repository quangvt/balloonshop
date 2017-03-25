using System.Collections.Generic;

namespace BalloonShop.Domain.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> list { get; }
        void Save(T item);
        T Delete(int id);
    }
}
