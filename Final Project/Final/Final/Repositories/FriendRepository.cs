using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Final.Objects;

namespace Final.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly IConfiguration _config;

        public FriendRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public virtual void addFriend(string uid, string fid)
        {
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("AddFriend", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@fid", fid);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public virtual List<Friend> getFriends(string uid)
        {
            List<Friend> friends = new List<Friend>();
            Friend friend = null;
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("GetFriends", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    connection.Open();
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            friend = new Friend()
                            {
                                Id = r["Id"].ToString(),
                                Name = r["Name"].ToString(),
                                Email = r["Email"].ToString(),
                            };
                            friends.Add(friend);
                        }
                    }
                }
            }
            return friends;
        }

        public virtual void removeFriend(string uid, string fid)
        {
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("RemoveFriend", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@fid", fid);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
