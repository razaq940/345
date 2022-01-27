using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Chart
    {
        public long Id { get; set; }
        public long FkProduct { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public long FkTransaction { get; set; }
        public bool IsActive { get; set; }
        public long FkUserId { get; set; }
    }
}
