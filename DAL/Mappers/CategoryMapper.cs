using AutoMapper;
using DAL.Models;
using DAL.Models.Dtos.CategoryProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryProductCreateDto, CategoryProduct>();
            CreateMap<CategoryProduct, CategoryProductCreateDto>();
        }
    }

}
