using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.Models.Dtos.CategoryProduct;
using DAL.Models.Dtos.DescriptionProduct;
using System.Threading.Tasks;

namespace DAL.Models.Dtos.Product
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Name Product Can't Be Empty")]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Description Product Can't Be Empty")]
        public DescriptionProductCreateDto Description { get; set; }
        [Required(ErrorMessage  = "PriceBuy Product Can't Be Empty")]
        public long PriceBuy { get; set; }
        [Required(ErrorMessage = "PriceSell Product Can't Be Empty")]
        public long PriceSell { get; set; }
        public long FkCategory { get; set; }
        public CategoryProductCreateDto AddNewCategory { get; set; }




    }
}
