namespace BalloonShop.Domain.Entities
{
    public class Address
    {
        // Complex Type does not have Key Column
        //public int AddressId { get; set; } 
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    //[ComplexType]
    //public class Address
    //{        
    //    public int AddressId { get; set; } 
    //    public string Street { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }
    //    public string Zip { get; set; }
    //}
}
