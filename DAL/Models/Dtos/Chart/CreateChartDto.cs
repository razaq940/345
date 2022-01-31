using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Dtos.Chart
{
    public class CreateChartDto
    {
        [Required]
        public long FkProduct { get; set; }
        public int Quantity { get; set; }

    }
}
