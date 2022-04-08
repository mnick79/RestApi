using RestApi.Interfaces;

namespace RestApi.Models
{
    public class Cart : IEntity
    {
        public int Number { get; set; }
        public decimal
            TotalPrice { get; set; }
        public string Description { get; set; }
        public int CustomerNumber { get; set; }
        public Cart() { }
        public Cart(int numberValue, decimal totalPriceValue, string descriptionValue, int customerNumberValue):base() 
        {
            Number = numberValue;
            TotalPrice=totalPriceValue;
            Description=descriptionValue;
            CustomerNumber = customerNumberValue;
        }
    }
}
