using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.Interfaces;
using RestApi.Interfaces.Implimentation;
using RestApi.Models;
using RestApi.Repository.Vip;
using System.Collections.Generic;

namespace RestApi.Repository.Implimentation
{
    public class RepoCart : RepoBase<Cart>
    {
        private string _sql;
        private Cart _cart;
        private readonly Postgres _postgres;
        public RepoCart() : base()
        {
            _postgres = new Postgres();
        }

        public override Cart Get(int number)
        {
            _cart = new Cart();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from product where number={number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    _cart = new Cart(read.GetInt32(0), read.GetDecimal(1), read.GetString(2), read.GetInt32(3));
                }
                conn.Close();
            }
            return _cart;
        }

        public override List<Cart> GetAll(int customerNumber)
        {
            List<Cart> list = new List<Cart>();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from cart where customer_number={customerNumber}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Cart(read.GetInt32(0), (read.GetValue(1)==null)?0: read.GetDecimal(1), (read.GetValue(2)==null)?string.Empty: read.GetString(2), read.GetInt32(3)));
                    
                }
                conn.Close();
            }
            return list;
        }

        public override void Post(Cart entity)
        {

            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"insert into cart (number, customer_number, totalprice) " +
                        $"values((select nextval('cart_number_seq')), {entity.CustomerNumber}, {entity.TotalPrice} ) returning number; " +
                        $"select setval('cart_number_seq', (select max(number) from cart));";

                _sql += new VipAutoComplite().PostToCart(entity, discont);
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void Put(Cart entity)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {

                _sql = $"update cart set customer_number={entity.CustomerNumber} where number={entity.Number};";
                _sql += new VipAutoComplite().PutToCart(entity, discont);
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

