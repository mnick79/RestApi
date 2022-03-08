using Npgsql;
using System;
using System.Collections.Generic;

namespace RestApi.ConnBD
{
    // Подключение к постгрес БД mnick, БД не закрывается после выполнения метода.
    public static class ConnectDB
    {
        private static readonly string _connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=123454321;Database=demoshop;";
        public static NpgsqlConnection Connect()
        {
            NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

                throw new Exception("Error connecting to the database");
            }
            return conn;
        }
        public static NpgsqlDataReader Reader(string sql)
        {
            NpgsqlConnection conn = ConnectDB.Connect();

            var cmd = new NpgsqlCommand(sql, conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            return reader;
             
        }
        public static int? FieldSearch(string sql)
        {
            NpgsqlConnection conn = ConnectDB.Connect();

            var cmd = new NpgsqlCommand(sql, conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            var read = ConnectDB.Reader(sql);
            while (read.Read())
            {
                return read.GetInt32(0);
            }
            return null;
        }
        public static void  ExeNoQuery(string sql)
        {
            NpgsqlConnection conn = ConnectDB.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static string AutoDescription()
        {
            return $@"update cart as cart1
                           set description = (select 
                           SUBSTRING(
                           STRING_AGG(p.name || '/count:'|| d.count || '/price:'|| p.price, '|') 
                           FROM 0 FOR 254) 
                           from customer c 
                           join  cart on c.id=cart.customer_id 
                           join details d on cart.number=d.cart_number 
                           join product p on d.product_number=p.number 
                           where cart.customer_id=cart1.customer_id)
                           where cart1.number=(select currval('cart_number_seq'));";
        }
        public static string AutoDescription(int cart_number)
        {
            return $@"update cart as cart1 set totalprice = (select sum(d.count * p.price)
                    from cart join details d on cart.number = d.cart_number
                    join product p on d.product_number = p.number
                    where cart.customer_id = cart1.customer_id)
                    where cart1.number = {cart_number};";
        }
        public static string AutoSumTotalprice()
        {
            return $@"update cart as cart1
                        set totalprice = (select sum(d.count*p.price) 
                        from cart join details d on cart.number=d.cart_number 
                        join product p on d.product_number=p.number 
                        where cart.customer_id=cart1.customer_id)
                        where cart1.number=(select currval('cart_number_seq'));";
        }
        public static string AutoSumTotalprice(int cart_number)
        {
            return @$"update cart as cart1 set totalprice = (select sum(d.count * p.price)
                    from cart join details d on cart.number = d.cart_number
                    join product p on d.product_number = p.number
                    where cart.customer_id = cart1.customer_id)
                    where cart1.number = {cart_number};
                    ";
            

        }
    }
}
