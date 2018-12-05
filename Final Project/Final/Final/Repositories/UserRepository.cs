using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Final.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public virtual bool getRestrict(string uid)
        {
            bool restrictStatus = false;
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("GetRestrict", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    connection.Open();
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            restrictStatus = (bool)r["Restricted"];
                        }
                    }
                }
            }
            return restrictStatus;
        }

        public virtual void restrict(string uid, bool ifRestrict)
        {
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("RestrictUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@restrict", ifRestrict);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public virtual void setName(string uid, string name)
        {
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("SetName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@name", name);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
