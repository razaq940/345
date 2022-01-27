using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class StatusTransaction
    {
        public long Id { get; set; }
        public string CodeStatusTransaction { get; set; }
        public long NameStatusTransaction { get; set; }
    }
}