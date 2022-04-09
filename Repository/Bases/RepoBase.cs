using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using System.Collections.Generic;

namespace RestApi.Interfaces.Implimentation
{
    public abstract class RepoBase<T> : IRepo<T> where T : IEntity
    {
        protected const decimal discont = 0.9M;
        protected readonly Postgres _database;
        public RepoBase()
        {
            _database = new Postgres();
        }

        public abstract List<T> GetAll(int limit);
        public abstract T Get(int number);
        public abstract void Post(T entity);
        public abstract void Put(T entity);

        public virtual void Delete(int number)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"delete from {typeof(T).Name} where number={number}; " +
                 $"select setval('cart_number_seq', (select max(number) from cart)); " +
                 $"select setval('details_number_seq', (select max(number) from details));";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool IsExist(int number)
        {
            bool rezultIsExist = false;
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select number from {typeof(T).Name} where number={number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezultIsExist = read.HasRows;
                }
                conn.Close();
            }
            return rezultIsExist;
        }
    }
}
