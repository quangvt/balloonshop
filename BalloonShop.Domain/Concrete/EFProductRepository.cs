using BalloonShop.Domain.Abstract;
using System.Collections.Generic;
using BalloonShop.Domain.Entities;

namespace BalloonShop.Domain.Concrete
{
    public class EFProductRepository : IRepository<Product>
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
                    //dbEntry.Category = inObj.Category;
                    dbEntry.ImageData = item.ImageData;
                    dbEntry.ImageMimeType = item.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
    }
}
