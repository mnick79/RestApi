using RestApi.Domains.BaseEntity;

namespace RestApi.Domains
{
    public class Customer: Entity
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Vip { get; set; }
    }
}
