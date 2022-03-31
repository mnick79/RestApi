using RestApi.DBContext.Implimentations;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.Interfaces;
namespace RestApi.Factories.Implimentations
{
    public class DeleteFactory : IDeleteFactory
    {
        private string _sql;
        private readonly Entity _entity;
        
        public DeleteFactory(Entity entity)
        {
            _entity=entity;
        }
        public void DeleteOption(int id)
        {
            _sql = $"delete from {_entity.GetType().Name} where number={id}; " +
                $"select setval('{_entity.GetType().Name}_number_seq', (select max(number) from details)); ";
            if (_entity.GetType().Name == "Details")
            {
                Details details = (Details)_entity;
                VipFactory vipFactory = new VipFactory();
                // Реализация автосуммы после удаления новой детализации
                _sql += vipFactory.AutoSumm(details, details.CartNumber);
                // Реализация автозаполнения после удаления новой детализации
                _sql += "select setval('cart_number_seq', (select max(number) from cart));";
                _sql += vipFactory.AutoDescription(details.CartNumber);
            }
            DatabaseContextDeleteOne databaseContextDeleteOne=new DatabaseContextDeleteOne();
            databaseContextDeleteOne.DeleteOneSql(_sql);
        }
    }
}
