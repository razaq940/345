using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Dtos.Product
{
    public class AddImageProductDto
    {
        public List<IFormFile> Image { get; set; }
        
    }
}
