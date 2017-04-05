using System;
using System.ComponentModel.DataAnnotations;

namespace BalloonShop.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Added Date")]
        public DateTime DateAdded { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
