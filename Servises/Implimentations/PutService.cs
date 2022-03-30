using RestApi.Domains.BaseEntity;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;

namespace RestApi.Servises.Implimentations
{
    public class PutService : IPutService
    {
        private Entity _entity;
        public PutService(Entity entity)
        {
            _entity = entity;
        }
        public void Put(int id)
        {
            PutFactory putFactory = new PutFactory(_entity);
            putFactory.PutOption(id);
        }
    }
}
