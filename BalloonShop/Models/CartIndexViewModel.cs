using BalloonShop.Domain.Entities;

namespace BalloonShop.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}