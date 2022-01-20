using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Models.Dtos.Store
{
    public class StoreDetailToCustomerDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public string Phone { get; set; }
        public Address Addresses { get; set; }
    }
}
