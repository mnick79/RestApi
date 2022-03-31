using RestApi.Domains.BaseEntity;
using RestApi.Factories.ExtensionEntity;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;
using System.Collections.Generic;

namespace RestApi.Servises.Implimentations
{
    public class GetAllService: IGetAllService
    {
        private readonly GetAllFactory _getAllFactory;
        public GetAllService(GetAllFactory getAllFactory)
        {
            _getAllFactory = getAllFactory;
        }
        public List<Entity> GetAll(int customer_number=0, int cart_number=0)
        {
            return _getAllFactory.GetAllOption(customer_number : customer_number, cart_number : cart_number);
        }
    
    }
}
