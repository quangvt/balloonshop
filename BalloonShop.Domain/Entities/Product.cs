using BalloonShop.Domain.Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BalloonShop.Domain.Entities
{
    [NoJoeOnMondays]
    public class Product
    // public class Product : IValidatableObject
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

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        //[MustBeTrue(ErrorMessage="You must accept the terms")] // Custom Attribute
        //public bool TermsAccepted { get; set; }

        // The Validate method will be called after
        //   the model binder has assigned values to each of the model properties
        /* IValidatableObject implement: Self-validating object
        public IEnumerable<ValidationResult> Validate(ValidationContext
validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name"));
            }
            if (DateTime.Now > Date)
            {
                errors.Add(new ValidationResult("Please enter a date in the future"));
            }
            if (errors.Count == 0 && ClientName == "Joe"
            && Date.DayOfWeek == DayOfWeek.Monday)
            {
                errors.Add(
                new ValidationResult("Joe cannot book appointments on Mondays"));
            }
            if (!TermsAccepted)
            {
                errors.Add(new ValidationResult("You must accept the terms"));
            }
            return errors;
        }
        */
    }
}
