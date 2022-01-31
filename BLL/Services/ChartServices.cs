using AutoMapper;
using System;
using DAL.Models.Dtos.Chart;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ChartServices
    {
        private readonly IMapper _mapper;

        public ChartServices(IMapper mapper)
        {
            _mapper = mapper;
        }



        public Tuple<int, List<ChartDto>, string> GetChart(long userId)
        {
            List<ChartDto> Charts = new List<ChartDto>();
            using (var _context = new StoreDbContext())
            {
                try
                {
                    var charts = _context.Charts.Where(c => c.FkUserId == userId).Where(p => p.IsActive == true).ToList();
                    foreach (var objcar in charts)
                    {
                        var productName = _context.Products.Where(p => p.Id == objcar.FkProduct).FirstOrDefault().Name;
                        var chart = _mapper.Map<ChartDto>(objcar);
                        chart.NameProduct = productName;
                        Charts.Add(chart);
                    }
                    if (Charts == null)
                    {
                        return Tuple.Create(-1, Charts, "Your chart is Empty");
                    }
                    return Tuple.Create(1, Charts, "Succes Get Charts");

                }
                catch (Exception Ex)
                {
                    return Tuple.Create(-1, Charts, Ex.Message);
                }
            }
        }

        public Tuple<int, string> AddChart(CreateChartDto data,long userId)
        {
            using (var _context = new StoreDbContext())
            {
                try
                {
                    var product = _context.Products.Where(p => p.Id == data.FkProduct).FirstOrDefault();
                    var stokProduct = product.Stock;
                    var chartActif = _context.Charts.Where(c => c.FkProduct == product.Id).Where(p => p.IsActive == true).Where(q => q.FkUserId == userId).FirstOrDefault();
                    if (chartActif != null)
                    {
                        chartActif.Quantity += data.Quantity;
                        chartActif.Price += data.Quantity * product.PriceSell;
                        _context.Update(chartActif);
                        _context.SaveChanges();
                        return Tuple.Create(1, "Succes add product to chart");
                    }
                    if (product == null || stokProduct < 1)
                    {
                        return Tuple.Create(-1, "product not exist");
                    }
                    
                    var chart = _mapper.Map<Chart>(data);
                    chart.Price = product.PriceSell * chart.Quantity;
                    chart.FkUserId = userId;
                    _context.Charts.Add(chart);
                    _context.SaveChanges();
                    return Tuple.Create(1, "Succes add product to chart");
                }
                catch (Exception Ex)
                {
                    return Tuple.Create(-1, Ex.Message);
                }
            }
        }
    }
}
