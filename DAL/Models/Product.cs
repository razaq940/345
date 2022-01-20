using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Stock { get; set; }
        public long PriceBuy { get; set; }
        public long PriceSell { get; set; }
        public long FkCategory { get; set; }
        public long FkStore { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
