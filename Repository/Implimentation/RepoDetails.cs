using Npgsql;
using RestApi.Interfaces.Implimentation;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Repository.Implimentation
{
    public class RepoDetails : RepoBase<Details>
    {
        private string _sql;
        private Details _details;
        public override Details Get(int number)
        {
            _details = null;
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"select * from details where number={number}; ";
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

        public override List<Details> GetAll(int cartNumber)
        {
            List<Details> list = new List<Details>();
            using (NpgsqlConnection conn = _database.Connect())
            {
                string _sql = $"select * from details where cart_number={cartNumber}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Details(read.GetInt32(0), read.GetInt32(1), read.GetInt32(2), read.GetInt32(3)));
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
                         $" count={entity.Count} where number={entity.Number}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public override void Delete(int number)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"delete from details where number={number}; " +
                 $"select setval('cart_number_seq', (select max(number) from cart)); " +
                 $"select setval('details_number_seq', (select max(number) from details));";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var write = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

