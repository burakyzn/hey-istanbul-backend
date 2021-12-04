using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Users;

namespace hey_istanbul_backend.Services.Interfaces
{
    public interface IUserService
    {
        ResultModel<object> Register(RegisterRequest request);
        ResultModel<object> Authenticate(AuthenticateRequest request);
    }
}