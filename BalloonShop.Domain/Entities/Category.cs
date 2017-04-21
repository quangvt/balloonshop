using System;
using System.Collections.Generic;
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
        [Display(Name = "DateAdded")]
        public DateTime DateAdded { get; set; }

        // Test Commit SSH via VS2017

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
