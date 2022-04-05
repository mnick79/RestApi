using RestApi.Interfaces;

namespace RestApi.Models
{
    public class NewCart : IEntity
    {
        public int Number { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public int CustomerNumber { get; set; }
    }
}
