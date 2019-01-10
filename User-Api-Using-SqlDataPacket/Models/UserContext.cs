using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace User_Api_Using_SqlDataPacket.Models
{
    public class UserContext
    {
        public string ConnectionString { get; set; }
        
        public UserContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<UserItem> GetAllUsers()
        {
            List<UserItem> list = new List<UserItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserItem()
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            adress = reader.GetString("adress")                           
                        });
                    }
                }
            }
            return list;
        }

        public List<UserItem> GetUser(string id)
        {
            List<UserItem> list = new List<UserItem>();

            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserItem()
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            adress = reader.GetString("adress")
                        });
                    }
                }
            }
            return list;
        }
    }
}
