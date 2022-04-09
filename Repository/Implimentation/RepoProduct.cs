using Npgsql;
using RestApi.Interfaces.Implimentation;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Repository.Implimentation
{
    public class RepoProduct : RepoBase<Product>
    {
        private string _sql;

        public override Product Get(int number)
        {
            Product _product = null;
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"select * from product where number={number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    _product = new Product(read.GetInt32(0), read.GetString(1), read.GetDecimal(2));
                }
                conn.Close();
            }
            return _product;
        }
        public override List<Product> GetAll(int limit)
        {
            List<Product> list = new List<Product>();
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"select * from product order by number limit {limit}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Product(read.GetInt32(0), read.GetString(1), read.GetDecimal(2)));
                }
                conn.Close();
            }
            return list;
        }
        public override void Post(Product entity)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"insert into product (number, name, price) " +
                        $"values ((select nextval('product_number_seq')), '{entity.Name}', {entity.Price.ToString().Replace(',', '.')}) returning number; " +
                        $"select setval('product_number_seq', (select max(number) from product));";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void Put(Product entity)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"update product set name='{entity.Name}', price = {entity.Price} where number={entity.Number};";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

