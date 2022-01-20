using AutoMapper;
using DAL.Models;
using DAL.Models.Dtos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class StoreMapper : Profile
    {
        public StoreMapper()
        {
            CreateMap<Store, CreateStoreDto>();
            CreateMap<CreateStoreDto, Store>();
            CreateMap<Store, StoreDetailAdminDto>();
            CreateMap<Store, StoreDetailToCustomerDto>();
        }
    }
}
