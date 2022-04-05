using Npgsql;
using RestApi.Database.Postgres.Implimentations;

namespace RestApi.Interfaces.Implimentation
{
    public class RepoDelete<T> : IRepoDelete<T> where T : IEntity
    {
        private readonly Postgres _database;

        public RepoDelete(Postgres database)
            {
                _database = database;
        }

        public void Delete(int number)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"delete from {typeof(T).Name} where number={number}; " +
                $"select setval('{typeof(T).GetType().Name}_number_seq', (select max(number) from {typeof(T).GetType().Name})); ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        
    }
}
