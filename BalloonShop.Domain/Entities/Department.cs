using System.Collections.Generic;

namespace BalloonShop.Domain.Entities
{
    public class Department
    {
        public Department()
        {
            Categories = new HashSet<Category>();
        }
        //TODO: Define attribute for Identity (1,1)
        public int DepartmentId { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }

        //[MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
