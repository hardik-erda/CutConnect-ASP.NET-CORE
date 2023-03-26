namespace CutConnect_ASP.NET_CORE.Models;
using MySql.Data.MySqlClient;

public class ShopModel
{
        public int Shopid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Open_time { get; set; }
        public string pincode { get; set; }
        public string Userid { get; set; }
        public string Created_at { get; set; }

        MySqlConnection conn = new MySqlConnection("server=localhost;port=3360;user id=root;database=cutconnect");
        public List<ShopModel> AllShops(){
        conn.Open();
        string sql = "select shop_id, name, city from shop where userid=@userid ORDER BY shop_id DESC";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@userid", 4);


        MySqlDataReader reader = cmd.ExecuteReader();
        List<ShopModel> shops=  new List<ShopModel>();

        while (reader.Read())
        {
          shops.Add(new ShopModel{
                Shopid = Convert.ToInt32(reader["shop_id"]),
                Name = reader["name"].ToString(),
                City = reader["city"].ToString(),
            });
        }
            conn.Close();
            return shops ;
}
        
        public List<ShopModel> ShopDetails(){
        conn.Open();
        string sql = "select shop_id, name, city from shop where shop_id=@shop_id ORDER BY shop_id DESC";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@userid", 4);


        MySqlDataReader reader = cmd.ExecuteReader();
        List<ShopModel> shops=  new List<ShopModel>();

        while (reader.Read())
        {
          shops.Add(new ShopModel{
                Shopid = Convert.ToInt32(reader["shop_id"]),
                Name = reader["name"].ToString(),
                City = reader["city"].ToString(),
            });
        }
            conn.Close();
            return shops ;
}
}
