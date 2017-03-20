using BalloonShop.Domain.Entities;
using System.Collections.Generic;

namespace BalloonShop.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void Save(Product dept);
        Product Delete(int productId);
    }
}
