using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class CategoryProduct
    {
        public long Id { get; set; }
        public string CategoryCode { get; set; }
        public string Category { get; set; }
    }
}
