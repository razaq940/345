using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public long FkTransactionType { get; set; }
        public string TransactionCode { get; set; }
        public long FkStatusTransaction { get; set; }
        public long FkPaymentType { get; set; }
        public long FkUserId { get; set; }
        public long TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
