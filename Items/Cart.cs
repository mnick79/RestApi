using System.Collections.Generic;
using Npgsql;
using RestApi.ConnBD;

namespace RestApi.Items
{
    public class Cart
    {
        private int number;
        private decimal totalPrice;
        private string description;
        private int customer_Id;

        public Cart() { }
        public Cart(decimal totalPrice, string description, int customer_Id)
        {
            this.totalPrice = totalPrice;
            this.description = description;
            this.customer_Id = customer_Id;
        }

        public Cart(int number, decimal totalPrice, string description, int customer_Id): this(totalPrice, description, customer_Id)
        {
            this.number = number;
        }
        public int Customer_Id
        {
            get { return customer_Id; }
            set { customer_Id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }


        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public static List<Cart> GetAllCart(string sql)
        {
            var rezult = new List<Cart>();

            var read = ConnectDB.Reader(sql);
            while (read.Read())
            {
                rezult.Add(new Cart(read.GetInt32(0), read.GetDecimal(1), read.GetString(2), read.GetInt32(3)));
            }
            return rezult;
        }
        public static Cart GetOneCart(int id)
        {
            string sql = $"select * from cart where number={id}";

            var read = ConnectDB.Reader(sql);

            if (read.HasRows)
            {
                while (read.Read())
                {
                   return new Cart(read.GetInt32(0), read.GetDecimal(1), read.GetString(2), read.GetInt32(3));
                }
            }
            return new Cart();
        }
        public static void DeleteOneCart(int id)
        {
            string sql = $"delete from cart where number={id}";
            NpgsqlConnection con = ConnectDB.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }

        }

    }
}
