using RestApi.Domains.BaseEntity;
using System.Collections.Generic;

namespace RestApi.Servises.Interfaces
{
    public interface IGetAllService
    {
        public List<Entity> GetAll(int customer_number = 0, int cart_number = 0);
    }
}
