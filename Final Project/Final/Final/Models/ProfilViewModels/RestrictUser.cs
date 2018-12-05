using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Final.Models.ProfilViewModels
{
    public class RestrictUser
    {
        [Required]
        public string Email { get; set; }
    }
}
