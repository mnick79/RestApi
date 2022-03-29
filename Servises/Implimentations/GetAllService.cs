using RestApi.Domains.BaseEntity;
using RestApi.Factories.ExtensionEntity;
using RestApi.Factories.Implimentations;
using System.Collections.Generic;

namespace RestApi.Servises.Implimentations
{
    public class GetAllService
    {
        private readonly Entity _entity;
        public GetAllService(Entity entity)
        {
            _entity=entity;
        }
        public List<Entity> GetAll(int customer_number=0, int cart_number=0)
        {
            GetAllFactory  getAllFactory = new GetAllFactory(_entity);
            return getAllFactory.GetAllOption(customer_number : customer_number, cart_number : cart_number);
        }
    
    }
}
