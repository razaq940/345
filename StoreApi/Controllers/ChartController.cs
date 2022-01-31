using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using BLL.Services;
using DAL.Models;
using DAL.Models.Dtos.Chart;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly ChartServices _chart;

        public ChartController(IMapper mapper, ChartServices chart)
        {
            _mapper = mapper;
            _chart = chart;
        }

        [HttpGet("[action]")]
        [Authorize]
        public ActionResult GetChart()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            long userId = long.Parse(identity.FindFirst("userId").Value);
            try
            {
                var result = _chart.GetChart(userId);
                if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Headers = Response.Headers,
                        Error = true,
                        Message = result.Item3
                    });
                }
                return Ok(new
                {
                    StatusCode = 200,
                    Headers = Response.Headers,
                    Error = false,
                    Chart = result.Item2,
                    Message = result.Item3
                });
            }
            catch (Exception Ex)
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Headers = Response.Headers,
                    Error = true,
                    Message = Ex.Message
                });
            }
        }

        [HttpPost("[action]")]
        [Authorize]
        public ActionResult AddChart(CreateChartDto data)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            long userId = long.Parse(identity.FindFirst("userId").Value);
            try
            {
                var result = _chart.AddChart(data, userId);
                if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Headers = Response.Headers,
                        Error = true,
                        Message = result.Item2
                    });
                }
                return Ok(new
                {
                    StatusCode = 200,
                    Headers = Response.Headers,
                    Error = false,
                    Message = result.Item2
                });
            }
            catch(Exception Ex)
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Headers = Response.Headers,
                    Error = true,
                    Message = Ex.Message
                });
            }
        }

    }
}
