using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Models;
using Final.Objects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Final.Repositories
{
    public class PostCachingRepository : PostRepository
    {
        private readonly string _CachePrefix = "PostCacheRepo";
        private IMemoryCache _Cache;
        private string _CacheListKey { get { return $"{_CachePrefix}_List"; } }
        public PostCachingRepository(IConfiguration configuration, UserManager<ApplicationUser> userManager, IMemoryCache cache) : base(configuration, userManager)
        {
            _Cache = cache;
        }

        public override void addPost(string uid, string content)
        {
            base.addPost(uid, content);
            _Cache.Remove(_CacheListKey+uid);
        }

        public override List<Post> getPosts(string uid)
        {
            var postList = (List<Post>)_Cache.Get(_CacheListKey+uid);
            if (postList != null)
            {
                return postList;
            }
            else
            {
                postList = base.getPosts(uid);
                _Cache.Set(_CacheListKey+uid, postList);
                return postList;
            }
        }

        public override void removePost(string uid, int pid)
        {
            base.removePost(uid, pid);
            _Cache.Remove(_CacheListKey+uid);
        }
    }
}
