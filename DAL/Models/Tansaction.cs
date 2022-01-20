using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Tansaction
    {
        public long Id { get; set; }
        public long FkTransactionType { get; set; }
        public string TransactionCode { get; set; }
        public long FkProduct { get; set; }
        public int QuantityProduct { get; set; }
    }
}
