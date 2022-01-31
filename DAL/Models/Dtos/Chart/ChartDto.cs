using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Dtos.Chart
{
    public class ChartDto
    {
        public string NameProduct { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }

    }
}
