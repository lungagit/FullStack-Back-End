using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStack.Data.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public string AdvertDetails { get; set; }
        public decimal Price  { get; set; }
        public bool Hidden { get; set; }
        public bool Deleted { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
