using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Objects;

namespace Final.Repositories
{
    public interface IFriendRepository
    {
        void addFriend(string uid, string fid);
        void removeFriend(string uid, string fid);
        List<Friend> getFriends(string uid);
    }
}
