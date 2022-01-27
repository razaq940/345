using AutoMapper;
using System;
using DAL.Models;
using DAL.Models.Dtos.DescriptionProduct;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class DescriptionProductMapper : Profile
    {
        public DescriptionProductMapper()
        {
            CreateMap<DescriptionProductCreateDto, DescriptionProduct>();
            CreateMap<DescriptionProduct, DescriptionProductCreateDto>();
        }
    }
}
