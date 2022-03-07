using Npgsql;
using RestApi.ConnBD;
using System.Collections.Generic;

namespace RestApi.Items
{
    public class Details
    {
        private int id;
        private int cart_number;
        private int product_number;
        private int count;


        public Details() { }
        public Details(int id, int cart_number, int product_number, int count)
        {
            this.id = id;
            this.cart_number = cart_number;
            this.product_number = product_number;
            this.count = count;

        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        public int Product_number
        {
            get { return product_number; }
            set { product_number = value; }
        }


        public int Cart_number
        {
            get { return cart_number; }
            set { cart_number = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static List<Details> GetListDetailsByCartNumber(int cart_number)
        {
            List<Details> rezult = new List<Details>();

            string sql = $"select * from details where cart_number={cart_number};";
            var read = ConnectDB.Reader(sql);
            while (read.Read())
            {
                rezult.Add(new Details(read.GetInt32(0), cart_number, read.GetInt32(2), read.GetInt32(3)));
            }
            return rezult;
        }
        public static void DeleteOneDetails(int id)
        {
            int? cart_number = ConnectDB.FieldSearch($"select cart_number from details where id={id}");

            if ((ConnectDB.FieldSearch($"select id from details where id={id}") != null) && (cart_number != null))
                {
                string sql = @$"delete from details where id={id};
                    update cart as cart1 set totalprice = (select sum(d.count * p.price)
                    from cart join details d on cart.number = d.cart_number
                    join product p on d.product_number = p.number
                    where cart.customer_id = cart1.customer_id)
                    where cart1.number = {cart_number};
                    update cart as cart1
                    set description = (select 
                    SUBSTRING(
                    STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                    FROM 0 FOR 254) 
                    from customer c 
                    join  cart on c.id=cart.customer_id 
                    join details d on cart.number=d.cart_number 
                    join product p on d.product_number=p.number 
                    where cart.customer_id=cart1.customer_id)
                    where cart1.number={cart_number};";

                NpgsqlConnection con = ConnectDB.Connect();
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            



        }


    }
}
