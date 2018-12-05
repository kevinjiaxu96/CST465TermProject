using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Objects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Final.Repositories
{
    public class FriendCachingRepository : FriendRepository
    {
        private readonly string _CachePrefix = "FriendCacheRepo";
        private IMemoryCache _Cache;
        private string _CacheListKey { get { return $"{_CachePrefix}_List"; } }
        public FriendCachingRepository(IConfiguration configuration, IMemoryCache cache) : base(configuration)
        {
            _Cache = cache;
        }

        public override void addFriend(string uid, string fid)
        {
            base.addFriend(uid, fid);
            _Cache.Remove(_CacheListKey+uid);
        }

        public override List<Friend> getFriends(string uid)
        {
            var friendList = (List<Friend>)_Cache.Get(_CacheListKey+uid);
            if (friendList != null)
            {
                return friendList;
            }
            else
            {
                friendList = base.getFriends(uid);
                _Cache.Set(_CacheListKey+uid, friendList);
                return friendList;
            }
        }

        public override void removeFriend(string uid, string fid)
        {
            base.removeFriend(uid, fid);
            _Cache.Remove(_CacheListKey+uid);
        }
    }
}
