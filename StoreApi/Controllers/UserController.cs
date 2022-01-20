using BLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DAL.Models.Dtos.User;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserServices _user;

        public UserController(IMapper mapper, UserServices user)
        {
            _mapper = mapper;
            _user = user;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserLoginDto data)
        {
            try
            {
                var result = _user.Login(data);
                if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Header = Response.Headers,
                        Error = true,
                        Message = result.Item4
                    });
                }
                else if (result.Item1 == 2)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Header = Response.Headers,
                        UserId = result.Item2,
                        Email = result.Item3,
                        Message = result.Item4
                    });
                }
                return Ok(new
                {
                    StatusCode = 200,
                    Header = Response.Headers,
                    UserId = result.Item2,
                    Token = result.Item3,
                    Error = false,
                    Message = result.Item4
                });
            }
            catch(Exception Ex)
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

        [HttpPut("ActivationUser")]
        public ActionResult ActivationUser(ActivationUserDto data)
        {
            try
            {
                var result = _user.ActivationUser(data);
                if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Headers = Response.Headers,
                        Error = true,
                        Message = result.Item2
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Headers = Response.Headers,
                        Error = false,
                        UserId = result.Item2,
                        Token = result.Item3,
                        Message = result.Item4
                    });
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Headers = Response.Headers,
                    Error = true,
                    Message = Ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult RegisterNewUser(UserCreateDto data)
        {
            try
            {
                var user = _mapper.Map<User>(data);
                var result = _user.RegisterNewUser(user);
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






