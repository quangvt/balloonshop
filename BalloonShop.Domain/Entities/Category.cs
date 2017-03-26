using System;

namespace BalloonShop.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
