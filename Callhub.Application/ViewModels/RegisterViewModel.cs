using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Callhub.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
