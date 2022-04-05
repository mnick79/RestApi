using RestApi.Interfaces;

namespace RestApi.Models
{
    public class NewDetails : IEntity
    {
        public int Number { get; set; }
        public int CartNumber { get; set; }
        public int ProductNumber { get; set; }
        public int Count { get; set; }
    }
}
