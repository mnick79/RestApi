using Npgsql;
using RestApi.Database.Interfaces;

namespace RestApi.Database.Postgres.Interfaces
{
    public interface IPostgreSql: IDatabase
    {
        public NpgsqlConnection Connect();
    }
}
