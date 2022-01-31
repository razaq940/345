using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Dtos.Product
{
    public class ProductStoreDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }

        public string Category { get; set; }
    }
}
