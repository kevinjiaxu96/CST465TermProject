using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Repositories
{
    public interface IUserRepository
    {
        void setName(string uid, string name);
        void restrict(string uid, bool ifRestrict);
        bool getRestrict(string uid);
    }
}
