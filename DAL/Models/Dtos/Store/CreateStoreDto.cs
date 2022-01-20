using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Dtos.Store
{
    public class CreateStoreDto
    {
        [Required(ErrorMessage = "Name Can't be null")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
