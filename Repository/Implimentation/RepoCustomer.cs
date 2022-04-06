using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.Interfaces;
using RestApi.Interfaces.Implimentation;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Repository.Implimentation
{
    public class RepoCustomer : RepoBase<Customer>
    {
        private string _sql;
        private Customer _customer;
        private readonly Postgres _postgres;
        public RepoCustomer() : base()
        {
            _postgres = new Postgres();
        }

        public override Customer Get(int number)
        {
            _customer = new Customer();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from customer where number={number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    _customer = new Customer(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetBoolean(4));
                    //_customer.Number = read.GetInt32(0);
                    //    _customer.FistName = read.GetString(1);
                    //    _customer.LastName = read.GetString(2);
                    //    _customer.Address = read.GetString(3);
                    //    _customer.Vip = read.GetBoolean(4);
                }
                conn.Close();
            }
            return _customer;
        }

        public override List<Customer> GetAll(int limit)
        {
            List<Customer> list = new List<Customer> ();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from customer order by number limit {limit}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read.Read())
                    {
                        _customer = new Customer();
                        _customer.Number = read.GetInt32(0);
                        _customer.FistName = read.GetString(1);
                        _customer.LastName = read.GetString(2);
                        _customer.Address = read.GetString(3);
                        _customer.Vip = read.GetBoolean(4);
                        list.Add(_customer);
                    }
                }
                conn.Close();
            }
            return list;
        }

        public override void Post(Customer entity)
        {

            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"insert into customer (number, first_name, last_name, address, vip) " +
                        $"values((select nextval('customer_number_seq')), '{entity.FistName}', '{entity.LastName}', " +
                        $"'{entity.Address}', {entity.Vip}) returning number; " +
                        $"select setval('customer_number_seq', (select max(number) from customer));";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void Put(Customer entity)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"update customer set first_name='{entity.FistName}', last_name='{entity.LastName}'," +
                        $"address='{entity.Address}', vip={entity.Vip} where number={entity.Number}";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
