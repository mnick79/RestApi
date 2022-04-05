using RestApi.Interfaces;

namespace RestApi.Models
{
    public class NewCustomer: IEntity
    {
        public int Number { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Vip { get; set; }
        
    }
}
