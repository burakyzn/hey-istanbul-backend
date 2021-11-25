using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Users;
using hey_istanbul_backend.Services;
using hey_istanbul_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hey_istanbul_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(
            IUserService userService
        ){
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public ResultModel<object> Authenticate([FromBody] AuthenticateRequest request)
        {
            return _userService.Authenticate(request);
        }

        [HttpPost("Register")]
        public ResultModel<object> Register([FromBody] RegisterRequest request)
        {
            return _userService.Register(request);
        }
    }
}
