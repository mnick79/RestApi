using RestApi.Domains.BaseEntity;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;

namespace RestApi.Servises.Implimentations
{
    public class GetOneService : IGetOneService
    {
        private readonly Entity _entity;
        public GetOneService(Entity entity)
        {
            _entity = entity;
        }
        public Entity GetOne(int number)
        {
            GetOneFactory getOneFactory = new GetOneFactory(_entity);

            return getOneFactory.GetOneOption(number);
        }
    }
}
