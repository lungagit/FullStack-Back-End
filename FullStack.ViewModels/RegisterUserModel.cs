using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullStack.ViewModels
{
    public class RegisterUserModel
    {
        public int Id { get; set; }

        [Required]
        public string Forenames { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
