using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Objects;

namespace Final.Repositories
{
    public interface IPostRepository
    {
        List<Post> getPosts(string uid);
        void addPost(string uid, string content);
        void removePost(string uid, int pid);

    }
}
