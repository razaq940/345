using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TransactionType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
