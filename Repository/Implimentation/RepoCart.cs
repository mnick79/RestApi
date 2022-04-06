using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.Interfaces;
using RestApi.Interfaces.Implimentation;
using RestApi.Models;
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

        public override List<Cart> GetAll(Cart entity)
        {
            List<Cart> list = new List<Cart>();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from cart order by number limit 10; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read.Read())
                    {
                        list.Add(new Cart(read.GetInt32(0), read.GetDecimal(1), read.GetString(2), read.GetInt32(3)));
                    }
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

                //Автосумма применяется, когда значение по умолчанию не изменялось,
                //в ином случае вносит изменения суммы автозаполнением
                //_sql += vipFactory.AutoSummForPostCartCurrentSeq(cart);
                // Автозаполнения cart.Decription, если cart.Decription равен "" или "string" при заполнении
                // Реализация на стороне БД


                //if (entity.Description.Trim() == "" || entity.Description.Trim() == "string")
                //{
                //    _sql += vipFactory.AutoDescription(0);
                //}
                //else
                //{
                //    _sql += $"update cart set description ='{cart.Description}' where number=(select currval('cart_number_seq'));";
                //}
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
                //Внесение автосуммы
                //_sql += vipFactory.AutoSumm(cart, id);
                // Реализация автозаполнения после побавления новой детализации
                //_sql += vipFactory.AutoDescription(id);
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        
    }
}

