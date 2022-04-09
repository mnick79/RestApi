using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.Models;

namespace RestApi.Repository.Vip
{
    public class IsVip
    {
        private readonly Postgres _database;
        private bool rezult = false;
        private string _sql;
        public IsVip()
        {
            _database = new Postgres();
        }
        public bool FromCart(Cart cart)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                 _sql = $"select vip from customer where number={cart.CustomerNumber}; ";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezult = read.GetBoolean(0);
                }
                conn.Close();
            }
            return rezult;
        }
        public bool FromDetails(Details details)
        {
            using (NpgsqlConnection conn = _database.Connect())
            {
                _sql = $"select vip from cart join customer on cart.customer_number=customer.number where cart.number={details.CartNumber};";
                NpgsqlCommand cmd = new NpgsqlCommand(_sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezult = read.GetBoolean(0);
                }
                conn.Close();
            }
            return rezult;
        }
    }
}

