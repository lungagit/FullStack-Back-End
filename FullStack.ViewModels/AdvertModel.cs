using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullStack.ViewModels
{
    public class AdvertModel
    {     
        public int Id { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string AdvertDetails { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool Hidden { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
