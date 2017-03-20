using BalloonShop.Domain.Entities;
using System.Data.Entity;

namespace BalloonShop.Domain.Concrete
{
    public class Initializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            //context.Category.Add(new Category
            //{
            //    DepartmentId = 1,
            //    Name = "My company",
            //    Description = "My company description"

            //});
        }
    }
}
