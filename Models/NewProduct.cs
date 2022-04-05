using RestApi.Interfaces;

namespace RestApi.Models
{
    public class NewProduct : IEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
