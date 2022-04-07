using RestApi.Interfaces;
using System.Collections.Generic;

namespace RestApi.DBContext.Interfaces
{
    public interface IDatabaseContextSelectAll
    {
        public List<IEntity> SelectAllSql(IEntity entity, string sql);
    }
}
