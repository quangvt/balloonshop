using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BalloonShop.Domain.Entities
{
    public class Department
    {
        // There is no Data Annotation for mapping Unicode

        public Department()
        {
            Categories = new HashSet<Category>();
        }

        //Define attribute for Identity (1,1) => Auto by Code First
        public int DepartmentId { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }

        //[MaxLength(1000)]
        public string Description { get; set; }

        // Optimistic Concurrency Check
        //[Timestamp]
        public byte[] RowVersion { get; set; }
        //[ConcurrencyCheck]
        //public int SocialSecurityNumer {get; set;}

        public virtual ICollection<Category> Categories { get; set; }
    }
}
