using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BalloonShop.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        // Remote validate: execute in the first time submit
        //  and each time user edit later. So need to consider
        //  to apply this validation type
        [Remote("ValidateName", "Product")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }
    }
}
