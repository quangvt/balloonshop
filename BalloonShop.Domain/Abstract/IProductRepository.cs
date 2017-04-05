using BalloonShop.Domain.Entities;
using System.Collections.Generic;

namespace BalloonShop.Domain.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        //IEnumerable<Product> list { get; }
        //void Save(Product item);
        //Product Delete(int id);
        IEnumerable<Category> GetCategories();
        
    }
}
