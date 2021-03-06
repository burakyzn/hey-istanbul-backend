using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Users;
using hey_istanbul_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hey_istanbul_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(
            IUserService userService
        ){
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public ResultModel<object> Authenticate([FromBody] AuthenticateRequest request)
        {
            return _userService.Authenticate(request);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public ResultModel<object> Register([FromBody] RegisterRequest request)
        {
            return _userService.Register(request);
        }
    }
}
