using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Store
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long FkUser { get; set; }
        public bool? IsOpen { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
