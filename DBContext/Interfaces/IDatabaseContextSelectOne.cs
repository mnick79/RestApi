using Npgsql;
using RestApi.Interfaces;

namespace RestApi.DBContext.Interfaces
{
    public interface IDatabaseContextSelectOne
    {
        public IEntity SelectOneSql(IEntity entity, string sql);
    }
}
