using BalloonShop.Domain.Abstract;
using System.Collections.Generic;
using BalloonShop.Domain.Entities;

namespace BalloonShop.Domain.Concrete
{
    /// <summary>
    /// We will use MapToStoredProcedures method in
    ///   EntityTypeConfiguration subclass to apply the data manipulation
    ///   by Store Procedure
    /// </summary>
    public class EFProductSPRepository : IProductRepository
    {
        AppDbContext context = new AppDbContext();

        public IEnumerable<Product> list
        {
            get
            {
                var sql = @"Product_GetAlls {0}";
                var products = context.Database.SqlQuery<Product>(
                    sql,
                    -1);

                return products;
            }
        }

        public Product Delete(int id)
        {
            return null;
        }

        public void Save(Product item)
        {
            // ...
        }
    }
}
