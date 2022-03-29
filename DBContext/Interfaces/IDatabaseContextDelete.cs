using RestApi.Database.Postgres.Implimentations;

namespace RestApi.DBContext.Interfaces
{
    public interface IDatabaseContextDelete
    {
        public void DeleteOneSql(string sql);
    }
}
