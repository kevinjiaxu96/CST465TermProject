using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Final.Objects;

namespace Final.Models.ProfilViewModels
{
    public class Friends
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Friend> FriendList { get; set; }
    }
}
