using BalloonShop.Domain.Abstract;
using System.Collections.Generic;
using BalloonShop.Domain.Entities;

namespace BalloonShop.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        AppDbContext context = new AppDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Product; }
        }

        public Product Delete(int productId)
        {
            Product dbEntry = context.Product.Find(productId);
            if (dbEntry != null)
            {
                context.Product.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Save(Product inObj)
        {
            if(inObj.ProductId == 0)
            {
                context.Product.Add(inObj);
            }
            else
            {
                Product dbEntry = context.Product.Find(inObj.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = inObj.Name;
                    dbEntry.Description = inObj.Description;
                    dbEntry.Price = inObj.Price;
                    //dbEntry.Category = inObj.Category;
                    dbEntry.ImageData = inObj.ImageData;
                    dbEntry.ImageMimeType = inObj.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
    }
}
