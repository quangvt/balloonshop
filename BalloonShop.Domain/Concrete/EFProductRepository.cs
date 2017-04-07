using BalloonShop.Domain.Abstract;
using System.Collections.Generic;
using BalloonShop.Domain.Entities;
using System.Linq;

namespace BalloonShop.Domain.Concrete
{
    //public class EFProductRepository : IRepository<Product>
    public class EFProductRepository : IProductRepository
    {
        AppDbContext context = new AppDbContext();

        public IEnumerable<Product> list
        {
            get { return context.Product; }
        }

        public Product Delete(int id)
        {
            Product dbEntry = context.Product.Find(id);
            if (dbEntry != null)
            {
                context.Product.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Save(Product item)
        {
            if(item.ProductId == 0)
            {
                context.Product.Add(item);
            }
            else
            {
                Product dbEntry = context.Product.Find(item.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Description = item.Description;
                    dbEntry.Price = item.Price;
                    dbEntry.CategoryId = item.CategoryId;
                    dbEntry.ImageData = item.ImageData;
                    dbEntry.ImageMimeType = item.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            var query = from c in context.Category
                        orderby c.Name
                        select c;
            return query;
        }
    }
}
