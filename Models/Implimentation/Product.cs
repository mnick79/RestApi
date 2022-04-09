using RestApi.Interfaces;

namespace RestApi.Models
{
    public class Product : IEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product() { }
        public Product(int numberValue, string nameValue, decimal priceValue) :base()
        {
            Number = numberValue;
            Name = nameValue;
            Price = priceValue;
        }
    }
}
