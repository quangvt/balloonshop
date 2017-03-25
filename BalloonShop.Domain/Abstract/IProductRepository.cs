using BalloonShop.Domain.Entities;
using System.Collections.Generic;

namespace BalloonShop.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> list { get; }
        void Save(Product item);
        Product Delete(int id);
    }
}
