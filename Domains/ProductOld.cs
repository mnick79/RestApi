using RestApi.Domains.BaseEntity;

namespace RestApi.Domains
{
    public class ProductOld: Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
