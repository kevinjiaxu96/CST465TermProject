using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string StatusMessage { get; set; }

        [Display(Name = "Role code")]
        public string Role { get; set; }
    }
}
