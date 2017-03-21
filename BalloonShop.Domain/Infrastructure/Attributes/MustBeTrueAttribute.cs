using System.ComponentModel.DataAnnotations;

namespace BalloonShop.Domain.Infrastructure.Attributes
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        // This is the method that the model binder will call to validate 
        //   properties to which the attribute is applied
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
    }
}