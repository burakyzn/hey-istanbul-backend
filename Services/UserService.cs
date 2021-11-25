using System;
using System.Linq;
using hey_istanbul_backend.Data;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Users;
using hey_istanbul_backend.Services.Interfaces;

namespace hey_istanbul_backend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public UserService(
            ApplicationDbContext dbContext
        ){
            _dbContext = dbContext;
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

            return new ResultModel<object>(data : "Giris yapildi");
        }
    }
}