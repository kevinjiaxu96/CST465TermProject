using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using System.Data;
using Final.Models;

namespace Final.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostRepository(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _config = configuration;
            _userManager = userManager;
        }

        public virtual void addPost(string uid, string content)
        {
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("AddPost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@content", content);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public virtual List<Post> getPosts(string uid)
        {
            List<Post> posts = new List<Post>();
            Post post = null;
            ApplicationUser owner = _userManager.FindByIdAsync(uid).Result;
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("GetPosts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@uid", uid);
                    connection.Open();
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            post = new Post()
                            {
                                Id = (int)r["Id"],
                                ownerId = r["userId"].ToString(),
                                content = r["content"].ToString(),
                                date = r["created"].ToString(),
                                ownerName = (owner.Name != null ? owner.Name : owner.Email)
                            };
                            posts.Add(post);
                        }
                    }
                }
            }
            return posts;
        }

        public virtual void removePost(string uid, int pid)
        {
            using (SqlConnection connection = new SqlConnection(_config["Database:OIT:String"]))
            {
                using (SqlCommand command = new SqlCommand("RemovePost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pid", pid);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
