namespace CutConnect_ASP.NET_CORE.Models;
using MySql.Data.MySqlClient;

public class UserModel
{
        public string Userid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Is_active { get; set; }
        public string Created_at { get; set; }

        public bool Unauthenticated {get;set;}

        MySqlConnection conn = new MySqlConnection("server=localhost;port=3360;user id=root;database=cutconnect");
        public bool Register(UserModel obj){
            MySqlCommand command = new MySqlCommand("insert into user(name,email,password,phone,role) values(@name,@email,@password,@phone,@role)",conn);
            command.Parameters.AddWithValue("@name", obj.Name);
            command.Parameters.AddWithValue("@email", obj.Email);
            command.Parameters.AddWithValue("@password", obj.Phone);
            command.Parameters.AddWithValue("@phone", obj.Password);
            command.Parameters.AddWithValue("@role", obj.Role);
            conn.Open();
            int i = command.ExecuteNonQuery();

            conn.Close();
            return i == 1;
        }
        
        public List<UserModel> Login(UserModel obj){
        conn.Open();
        string sql = "select userid,role from user where email=@email and password=@password";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@email", obj.Email);
        cmd.Parameters.AddWithValue("@password", obj.Password);
        MySqlDataReader reader = cmd.ExecuteReader();
        List<UserModel> lst=  new List<UserModel>();
        
        if (reader.Read())
        {
            lst.Add(new UserModel{
                Unauthenticated = false,
                Role = reader["role"].ToString(),
                Userid = reader["userid"].ToString(),
            });
            conn.Close();
            return lst ;
        }
        else
        {
        lst.Add(new UserModel{
            Unauthenticated = true });
        }
        conn.Close();
        return(lst);
}
}
