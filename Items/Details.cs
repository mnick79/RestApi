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
                string sql = @$"delete from details where id={id};";
                sql += ConnectDB.AutoSumTotalprice((int)cart_number);
                sql += ConnectDB.AutoDescription((int)cart_number);
                ConnectDB.ExeNoQuery(sql);
            }
        }

        public static void PutDetails(int id, Details value)
        {
            string sql = "";
            if (value.count != 0) { sql += $"update details set count={value.count} where id={id}; "; }
            if (value.product_number != 0) { sql += $"update details set product_number={value.product_number} where id={id}; "; }
            if (value.cart_number != 0) { sql += $"update details set cart_number={value.cart_number} where id={id};"; }
            if (sql != "")
            {
                sql += ConnectDB.AutoSumTotalprice(value.cart_number);
                sql += ConnectDB.AutoDescription(value.cart_number);
            }
            ConnectDB.ExeNoQuery(sql);
        }
        public static void PostDetails(Details value)
        {
            if (value.id != 0) 
            {
                string sql = "";
                if (value.Count != 0) { sql += $"update details set count={value.Count} where id={value.Id};"; }
                if (value.cart_number !=0) { sql += $"update details set cart_number={value.cart_number} where id={value.Id};"; }
                if (value.product_number !=0) { sql += $"update details set product_number={value.product_number} where id={value.Id};"; }
                if (sql != "" && value.cart_number!=0)
                {
                    sql += ConnectDB.AutoDescription(value.cart_number);
                    sql += ConnectDB.AutoSumTotalprice(value.cart_number);
                    ConnectDB.ExeNoQuery(sql);
                }
            }
           
        }
    }
}
