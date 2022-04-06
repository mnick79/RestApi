using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.Interfaces;
using RestApi.Interfaces.Implimentation;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Repository.Implimentation
{
    public class RepoDetails : RepoBase<Details>
    {
        private string _sql;
        private Details _details;
        private readonly Postgres _postgres;
        public RepoDetails() : base()
        {
            _postgres = new Postgres();
        }
        public override Details Get(int number)
        {
            _details = new Details();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from details where number={number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    _details = new Details(read.GetInt32(0), read.GetInt32(1), read.GetInt32(2), read.GetInt32(3));
                }
                conn.Close();
            }
            return _details;
        }

        public override List<Details> GetAll(int limit)
        {
            List<Details> list = new List<Details>();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from details order by number limit 10; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read.Read())
                    {
                        list.Add(new Details(read.GetInt32(0), read.GetInt32(1), read.GetInt32(2), read.GetInt32(3)));
                    }
                }
                conn.Close();
            }
            return list;
        }

        public override void Post(Details entity)
        {

            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"insert into details (number, cart_number, product_number, count) " +
                        $"values ((select nextval('details_number_seq')), {entity.CartNumber}, {entity.ProductNumber},{entity.Count}) returning number; " +
                        $"select setval('details_number_seq', (select max(number) from details));";

                // Автосуммы в поле cart.Totalprice, если значение по умолчанию (равно нулю)
                // Реализация на строне БД. Определение VIP клиента на стороне API

                //_sql += vipFactory.AutoSumm(_entity, details.CartNumber);



                // Реализация автозаполнения после побавления новой детализации
                //_sql += vipFactory.AutoDescription(details.CartNumber);
                //_sql += $@"update cart as cart1
                //            set description = (select 
                //            SUBSTRING(
                //            STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                //            FROM 0 FOR 254) 
                //            from customer c 
                //            join  cart on c.number=cart.customer_number 
                //            join details d on cart.number=d.cart_number 
                //            join product p on d.product_number=p.number 
                //            where cart.customer_number=cart1.customer_number)
                //            where cart1.number={details.CartNumber};";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void Put(Details entity)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"update details set cart_number = {entity.CartNumber}, product_number={entity.ProductNumber}," +
                         $" count={entity.Count} where number={entity.Number};";
                //Внесение изменений в заказ после изменения в детализации
                // Автосуммы в поле cart.Totalprice, если значение по умолчанию (равно нулю)
                //_sql += vipFactory.AutoSumm(details, details.CartNumber);

                // Реализация автозаполнения после побавления новой детализации
                //_sql += vipFactory.AutoDescription(details.CartNumber);
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

