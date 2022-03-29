using RestApi.DBContext.Implimentations;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.Interfaces;
namespace RestApi.Factories.Implimentations
{
    public class DeleteFactory : IDeleteFactory
    {
        private string sql;
        private readonly Entity _entity;
        public DeleteFactory(Entity entity)
        {
            _entity=entity;
        }
        public void DeleteOption(int id)
        {
            sql = $"delete from {_entity.GetType().Name} where number={id}";
            DatabaseContextDeleteOne databaseContextDeleteOne=new DatabaseContextDeleteOne();
            databaseContextDeleteOne.DeleteOneSql(sql);
        }
    }
}
