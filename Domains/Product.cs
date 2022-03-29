using RestApi.Domains.BaseEntity;

namespace RestApi.Domains
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
