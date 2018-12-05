using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Objects
{
    public class Post
    {
        public int Id { get; set; }
        public string ownerName { get; set; }
        public string ownerId { get; set; }
        public string content { get; set; }
        public string date { get; set; }
    }
}
