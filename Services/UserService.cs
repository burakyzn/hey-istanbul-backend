using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using hey_istanbul_backend.Data;
using hey_istanbul_backend.Helpers;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Users;
using hey_istanbul_backend.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace hey_istanbul_backend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AppSettings _appSettings;
        
        public UserService(
            ApplicationDbContext dbContext,
            IOptions<AppSettings> appSettings
        ){
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
        }

        public ResultModel<object> Register(RegisterRequest request){
            UserEntity newUser = new UserEntity(){
                Id = Guid.NewGuid(),
                Nickname = request.Nickname,
                Password = request.Password
            };

            _dbContext.Add(newUser);
            _dbContext.SaveChanges();

            return new ResultModel<object>(data : "Kullanici olusturuldu!");
        }

        public ResultModel<object> Authenticate(AuthenticateRequest request){
            var user = _dbContext.Users
                .Where(user => user.Nickname == request.Nickname && user.Password == request.Password)
                .FirstOrDefault();

            if(user == null)
                return new ResultModel<object>(data : "Kullanici adi sifre yanlis", type: ResultModel<object>.ResultType.FAIL);

            var jwtToken = GenerateJwtToken(user);

            return new ResultModel<object>(data : new AuthenticateResponse(user.Id, jwtToken));
        }

        private string GenerateJwtToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(200),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}