using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Final.Objects;

namespace Final.Repositories
{
    public class UserCachingRepository : UserRepository
    {
        private readonly string _FriendCachePrefix = "FriendCacheRepo";
        private readonly string _PostCachePrefix = "PostCacheRepo";
        private IMemoryCache _Cache;
        private readonly IFriendRepository _friendRepo;
        private string _FriendCacheListKey { get { return $"{_FriendCachePrefix}_List"; } }
        private string _PostCacheListKey { get { return $"{_PostCachePrefix}_List"; } }

        public UserCachingRepository(IConfiguration configuration, IFriendRepository friendRepo,IMemoryCache cache) : base(configuration)
        {
            _Cache = cache;
            _friendRepo = friendRepo;
        }

        

        public override bool getRestrict(string uid)
        {
            return base.getRestrict(uid);
        }

        public override void restrict(string uid, bool ifRestrict)
        {
            base.restrict(uid, ifRestrict);
        }

        public override void setName(string uid, string name)
        {
            base.setName(uid, name);
            List<Friend> friends = _friendRepo.getFriends(uid);
            _Cache.Remove(_FriendCacheListKey + uid);
            _Cache.Remove(_PostCacheListKey + uid);
            for (int i = 0; i < friends.Count; ++i)
            {
                _Cache.Remove(_FriendCacheListKey + friends[i].Id);
                _Cache.Remove(_PostCacheListKey + friends[i].Id);
            }
        }
    }
}
