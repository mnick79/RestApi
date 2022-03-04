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
        private int customer_id;

        public Details() { }
        public Details(int id, int cart_number, int product_number, int count)
        {
            this.id = id;
            this.cart_number = cart_number;
            this.product_number = product_number;
            this.count = count;

        }
        public Details(int id, int cart_number, int product_number, int count, int customer_id) : this(id, cart_number, product_number, count)
        {
            this.customer_id = customer_id;
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
           


    }
}
