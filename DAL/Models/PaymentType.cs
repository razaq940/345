using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class PaymentType
    {
        public long Id { get; set; }
        public string CodePaymentType { get; set; }
        public string NamePaymentType { get; set; }
    }
}
