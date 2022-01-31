using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models.Dtos.Chart;
using DAL.Models;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class ChartMapper : Profile
    {
        public ChartMapper()
        {
            CreateMap<Chart, ChartDto>();
            CreateMap<CreateChartDto,Chart>();
        }
    }
}
