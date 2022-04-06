using RestApi.Interfaces;

namespace RestApi.Models
{
    public class Details : IEntity
    {
        public int Number { get; set; }
        public int CartNumber { get; set; }
        public int ProductNumber { get; set; }
        public int Count { get; set; }
        public Details() { }
        public Details(int numberValue, int cartNumberValue, int productNumberValue, int countValue) : base()
        {
            Number = numberValue;
            CartNumber = cartNumberValue;
            ProductNumber = productNumberValue;
            Count = countValue;
        }
    }
}
