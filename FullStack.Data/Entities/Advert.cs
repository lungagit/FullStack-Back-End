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
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Status { get; set; }
        public string AdvertDetails { get; set; }
        public decimal Price  { get; set; }
        public bool Hidden { get; set; }
        public bool Deleted { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
