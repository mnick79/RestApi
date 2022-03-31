using RestApi.Domains.BaseEntity;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;

namespace RestApi.Servises.Implimentations
{
    public class PutService : IPutService
    {
        private readonly PutFactory _putFactory;
        public PutService(PutFactory putFactory)
        {
            _putFactory = putFactory;
        }
        public void Put(int id)
        {
            _putFactory.PutOption(id);
        }
    }
}
