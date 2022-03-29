using Npgsql;
using RestApi.Domains.BaseEntity;

namespace RestApi.DBContext.Interfaces
{
    public interface IDatabaseContextSelectOne
    {
        public Entity SelectOneSql(Entity entity, string sql);
    }
}
