using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TransactionType
    {
        public long Id { get; set; }
        public string CodeTransactionType { get; set; }
        public string NameTransactionType { get; set; }
    }
}
