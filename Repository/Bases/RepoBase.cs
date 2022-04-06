using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using System.Collections.Generic;

namespace RestApi.Interfaces.Implimentation
{
    public abstract class RepoBase<T> : IRepo<T> where T : IEntity
    {
        protected readonly Postgres _database;

        public RepoBase()
        {
            _database = new Postgres();
        }

        public bool IsExist(int number)
        {
            bool rezultIsExist=false;
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select number from {typeof(T).Name} where number={number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteReader();
                while (write.Read())
                {
                    if (write.Read())
                    {
                        rezultIsExist = true;
                    }
                    else
                    {
                        rezultIsExist = true;
                    }
                }
                conn.Close();
            }
            return rezultIsExist;
        }

        public void Delete(int number)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"delete from {typeof(T).Name} where number={number}; " +
                $"select setval('{typeof(T).Name}_number_seq', (select max(number) from {typeof(T).Name})); ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public abstract T Get(int number);
        public abstract List<T> GetAll(int limit);
        public abstract void Post(T entity);
        public abstract void Put(T entity);
        
    }
}
