using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class DescriptionProduct
    {
        public long Id { get; set; }
        public string NameDescription { get; set; }
        public string DescriptionDetail { get; set; }
        public long ProductId { get; set; }
    }
}

