using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.DBContext.Interfaces;

namespace RestApi.DBContext.Implimentations
{
    public class DatabaseContextPut : IDatabaseContextPut
    {
        private Postgres database;
        public DatabaseContextPut()
        {
            database = new Postgres();
        }
        public void PutSql(string sql)
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
