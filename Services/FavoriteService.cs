using System;
using hey_istanbul_backend.Data;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Favorites;
using hey_istanbul_backend.Services.Interfaces;

namespace hey_istanbul_backend.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public FavoriteService(ApplicationDbContext dbContext){
            _dbContext = dbContext;
        }

        public ResultModel<object> CreateFavorite(CreateFavoriteRequest request)
        {
            throw new NotImplementedException();
        }

        public ResultModel<object> DeleteFavorite(Guid favoriteId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public ResultModel<object> GetFavoritesByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}