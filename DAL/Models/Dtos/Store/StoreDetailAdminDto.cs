using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Dtos.Store
{
    public class StoreDetailAdminDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
