using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.DBContext.Interfaces;
using RestApi.Domains.BaseEntity;

namespace RestApi.DBContext.Implimentations
{
    public class DatabaseContextDeleteOne : IDatabaseContextDelete
    {
        private readonly Postgres database;

        public DatabaseContextDeleteOne()
        {
            database = new Postgres();
        }
        public void DeleteOneSql(string sql)
        {
            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
