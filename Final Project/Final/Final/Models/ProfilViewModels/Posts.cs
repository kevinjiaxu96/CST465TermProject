using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Objects;
using System.ComponentModel.DataAnnotations;

namespace Final.Models.ProfilViewModels
{
    public class Posts
    {
        [Required(ErrorMessage = "You can't post nothing, the gods will be furious!")]
        [StringLength(500)]
        public string Content { get; set; }
        public int Id { get; set; }
        public List<Post> PostList { get; set; }
    }
}
