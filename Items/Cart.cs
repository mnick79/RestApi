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
        public List<Details> details;

        


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
            this.details = new List<Details>();
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

        public List<Details> Details
        {
            get { return details; }
            set { details = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public static List<Cart> GetAllCart(string sql)
        {
            var rezult = new List<Cart>();
            string sqlGetAllDetails = "";
            var read = ConnectDB.Reader(sql);
            while (read.Read())
            {
                Cart cart = new Cart(read.GetInt32(0), read.GetDecimal(1), read.GetString(2), read.GetInt32(3));

                sqlGetAllDetails = $"select * from details where cart_number={cart.number};";
                using (var readDL = ConnectDB.Reader(sqlGetAllDetails))
                {

                    while (readDL.Read())
                    {
                        Details temp = new Details();
                        temp.Id = readDL.GetInt32(0);
                        temp.Cart_number = readDL.GetInt32(1);
                        temp.Product_number = readDL.GetInt32(2);
                        temp.Count = readDL.GetInt32(3);
                        cart.details.Add(temp);

                    }
                }
                rezult.Add(cart);
            }
            return rezult;
        }
        public static Cart GetOneCart(int id)
        {
            string sql = $"select * from cart where number={id};";
            
            using (var read = ConnectDB.Reader(sql))
            {
                if (!(read.HasRows))
                {
                    return new Cart();
                }

                while (read.Read())
                {
                    Cart cart = new Cart(read.GetInt32(0), read.GetDecimal(1), read.GetString(2), read.GetInt32(3));
                    string sqlGetAllDetails = $"select * from details where cart_number={cart.number};";
                    using (var readDL = ConnectDB.Reader(sqlGetAllDetails))
                    {

                        while (readDL.Read())
                        {
                            Details temp = new Details();
                            temp.Id = readDL.GetInt32(0);
                            temp.Cart_number = readDL.GetInt32(1);
                            temp.Product_number = readDL.GetInt32(2);
                            temp.Count = readDL.GetInt32(3);
                            cart.details.Add(temp);
                           
                        }
                        return cart;
                    }
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
