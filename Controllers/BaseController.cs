using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace hey_istanbul_backend.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Guid GetActiveUserId(){
            var _claimIdentity = this.User.Identity as ClaimsIdentity;
            return Guid.Parse(_claimIdentity.FindFirst(ClaimTypes.Name)?.Value);
        }
    }
}