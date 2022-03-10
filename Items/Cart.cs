using System;
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

        public int Customer_Id { get { return customer_Id; } set { customer_Id = value; } }
        public string Description { get { return description; } set { description = value; } }
        public decimal TotalPrice { get { return totalPrice; } set { totalPrice = value; } }
        public List<Details> Details { get { return details; } set { details = value; } }
        public int Number { get { return number; } set { number = value; } }


        public Cart() { }
        public Cart(decimal totalPrice, string description, int customer_Id)
        {
            this.totalPrice = totalPrice;
            this.description = description;
            this.customer_Id = customer_Id;
        }

        public Cart(int number, decimal totalPrice, string description, int customer_Id) : this(totalPrice, description, customer_Id)
        {
            this.number = number;
            this.details = new List<Details>();
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
            read.Close();
            return rezult;
        }
        public static Cart GetOneCart(int id)
        {
            string sql = $"select * from cart where number={id};";
            var read = ConnectDB.Reader(sql);
            if (!(read.HasRows))
            {
                read.Close();
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
                    read.Close();
                    return cart;
                }
            }
            read.Close();
            return new Cart();
        }
        public static void DeleteOneCart(int id)
        {
            string sql = $"delete from cart where number={id};";
            NpgsqlConnection con = ConnectDB.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public static void PostCart(Cart cart)
        {
            string sql = $"insert into cart (number, totalprice, description, customer_id) values ((select nextval('cart_number_seq')),{cart.totalPrice}, '{cart.description}', {cart.customer_Id}) returning number; ";
            // Перебор List<Details> для добавления в таблицу details
            foreach (var item in cart.details)
            {
                sql += $"insert into details (id, cart_number, product_number, count) values ((select nextval('details_id_seq')),(select number from cart where totalprice={cart.totalPrice} and description='{cart.description}' and customer_id={cart.customer_Id}), {item.Product_number} , {item.Count}) returning id; ";
            }
            /* Валидация: введены ли значения или оставлены по умолчанию в поле описания заказа.
             В случае оставления по умолчанию выполняется скрип автонаполнения описания заказа*/

            if (cart.description == "" || cart.description == "string")
            {
                sql += ConnectDB.AutoDescription();
            }
            // Валидация: Если не введена сумма всех детализаций заказа, выполняется скрипт нахождения суммы
            if (cart.totalPrice == 0)
            {
                // Добавление дисконта, если полагается
                if (!(Customer.GetOnlyOneCustomer(cart.customer_Id).Vip))
                {
                    sql += ConnectDB.AutoSumTotalprice();
                }
                else
                {
                    sql += ConnectDB.Discont(cart);
                }

            }
            NpgsqlConnection con = ConnectDB.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public static void PutOneCart(int number, int customer_id)
        {
            string sql = $"update cart set customer_id={customer_id} where number={number};";

            NpgsqlConnection con = ConnectDB.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
