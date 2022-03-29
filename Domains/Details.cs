using RestApi.Domains.BaseEntity;

namespace RestApi.Domains
{
    public class Details: Entity
    {
        public int CartNumber { get; set; }
        public int ProductNumber { get; set; }
        public int Count { get; set; }
    }
}
