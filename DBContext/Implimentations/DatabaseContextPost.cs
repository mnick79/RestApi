using RestApi.Database.Postgres.Implimentations;
using RestApi.DBContext.Interfaces;
using Npgsql;
namespace RestApi.DBContext.Implimentations
{
    public class DatabaseContextPost : IDatabaseContextPost
    {
        private readonly Postgres database;
        public DatabaseContextPost()
        {
            database = new Postgres();
        }

        public void PostSql(string sql)
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
