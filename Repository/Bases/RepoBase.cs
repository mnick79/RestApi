using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.Models;
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

        public abstract T Get(int number);
        public abstract List<T> GetAll(int limit);
        public abstract void Post(T entity);
        public abstract void Put(T entity);
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
                    rezultIsExist = read.HasRows ? true : false;
                }
                conn.Close();
            }
            return rezultIsExist;
        }

        public bool IsVipFromCustomer(Customer customer)
        {
            bool rezultIsVip = false;
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select vip from customer where number={customer.Number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezultIsVip = read.GetBoolean(0);
                }
                conn.Close();
            }
            return rezultIsVip;
        } 
        public bool IsVipFromCart(Cart cart)
        {
            bool rezultIsVip = false;
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select vip from customer where number={cart.CustomerNumber}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezultIsVip = read.GetBoolean(0);
                }
                conn.Close();
            }
            return rezultIsVip;
        }
        public bool IsVipFromDetails(Details details)
        {
            bool rezultIsVip = false;
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select cust.vip from details d join cart c on d.cart_number=c.number " +
                    $"join customer cust on c.customer_number=cust.number where d.number={details.Number};; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezultIsVip = read.GetBoolean(0);
                }
                conn.Close();
            }
            return rezultIsVip;
        }
    }
}
