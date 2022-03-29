using RestApi.Domains.BaseEntity;
using System.Collections.Generic;

namespace RestApi.DBContext.Interfaces
{
    public interface IDatabaseContextSelectAll
    {
        public List<Entity> SelectAllSql(Entity entity, string sql);
    }
}
