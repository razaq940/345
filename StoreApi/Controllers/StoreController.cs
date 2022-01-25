using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using DAL.Models.Dtos.Store;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly StoreServices _store;

        public StoreController(IMapper mapper, StoreServices store)
        {
            _mapper = mapper;
            _store = store;
        }

        [Authorize]
        [HttpPut("[action]")]
        public ActionResult UpdateStore(UpdateStoreDto data)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                long userId = long.Parse(identity.FindFirst("userId").Value);
                var result = _store.UpdateStore(data, userId);
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
                    StoreId = result.Item2,
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

        [HttpGet("{id}")]
        public ActionResult GetStoreDetail(long id)
        {
            try
            {
                var result = _store.GetStoreDetailToCustomer(id);
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
                    Store = result.Item2,
                    Message = result.Item3
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

        [HttpGet("ListStoreToCustomer")]
        public ActionResult GetListStoreToCustomer()
        {
            try
            {
                var result = _store.GetAllStoreDetailToCustomer();
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
                    Stores = result.Item2,
                    Message = result.Item3
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



        [HttpGet]
        [Authorize(Roles = "Admin Store")]
        public ActionResult GetStoreDetailForAdmin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            long userId = long.Parse(identity.FindFirst("userId").Value);
            try
            {
                var result = _store.GetStores(userId);
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
                    Store = result.Item2,
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

        [HttpPost]
        [Authorize]
        public ActionResult CreateStore(CreateStoreDto data)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            long userId = long.Parse(identity.FindFirst("userId").Value);
            try
            {
                
                var store = _mapper.Map<Store>(data);
                var result = _store.CreateStore(store, userId);
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
                    StatusCode = 500,
                    Headers = Response.Headers,
                    Error = true,
                    Message = Ex.Message
                });
            }
        }
    }
}
