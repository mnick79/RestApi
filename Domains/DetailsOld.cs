using RestApi.Domains.BaseEntity;

namespace RestApi.Domains
{
    public class DetailsOld: Entity
    {
        public int CartNumber { get; set; }
        public int ProductNumber { get; set; }
        public int Count { get; set; }
    }
}
