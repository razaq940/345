using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using BLL.Services;
using AutoMapper;
using DAL.Models.Dtos.Product;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly ProductService _product;

        public ProductController(IMapper mapper, ProductService product)
        {
            _mapper = mapper;
            _product = product;
        }


        [Authorize(Roles = "Admin Store")]
        [HttpPost("multiple-files")]
        public ActionResult AddImageProduct(List<IFormFile> data, long ProductId)
        {
            try
            {
                var result = _product.AddImageProduct(data, ProductId);
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
            catch (Exception Ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Headers = Response.Headers,
                    Error = true,
                    Message = Ex.Message
                });
            }
        }

        [Authorize(Roles = "Admin Store")]
        [HttpPost]
        public ActionResult CreateProduct(ProductCreateDto data)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = long.Parse(identity.FindFirst("userId").Value);
            try
            {
                var objdesc = _mapper.Map<DescriptionProduct>(data.Description);
                var objCat = _mapper.Map<CategoryProduct>(data.AddNewCategory);
                var product = _mapper.Map<Product>(data);
                var result = _product.CreateProduct(data.FkCategory,product, userId, objdesc, objCat );
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
            catch (Exception Ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Headers = Response.Headers,
                    Error = true,
                    Message = Ex.Message
                });
            }
        }
    }
}
