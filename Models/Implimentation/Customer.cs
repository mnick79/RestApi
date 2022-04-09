using RestApi.Interfaces;

namespace RestApi.Models
{
    public class Customer: IEntity
    {
        public int Number { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Vip { get; set; }

        public Customer() { }
        public Customer(int numberValue, string firstNameValue, string lastNameValue, string addressValue, bool vipValue): base()
        {
            Number = numberValue;
            FistName = firstNameValue;
            LastName = lastNameValue;
            Address = addressValue;
            Vip = vipValue;
        }
        
    }
}
