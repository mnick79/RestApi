using RestApi.Domains.BaseEntity;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;

namespace RestApi.Servises.Implimentations
{
    public class GetOneService : IGetOneService
    {
        private readonly GetOneFactory _getOneFactory;
        public GetOneService(GetOneFactory getOneFactory)
        {
            _getOneFactory = getOneFactory;
        }
        public Entity GetOne(int number)
        {
            return _getOneFactory.GetOneOption(number);
        }
    }
}
