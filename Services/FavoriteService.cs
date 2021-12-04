using System;
using System.Linq;
using hey_istanbul_backend.Data;
using hey_istanbul_backend.Data.Entities;
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
            FavoriteEntity newFavorite = new FavoriteEntity{
                LocationId = request.LocationId,
                UserId = request.UserId
            };

            _dbContext.Add(newFavorite);
            _dbContext.SaveChanges();

            return new ResultModel<object>(data: newFavorite, message: "The favorite has been created.");
        }

        public ResultModel<object> DeleteFavorite(Guid favoriteId, Guid userId)
        {
            FavoriteEntity favorite = _dbContext.Favorites
                .Where(fav => fav.Id == favoriteId)
                .Where(fav => fav.UserId == userId)
                .Where(fav => fav.IsActive)
                .SingleOrDefault();
            
            if(favorite == null)
                return new ResultModel<object>(message: "The favorite couldn't be found!", type: ResultModel<object>.ResultType.FAIL);

            favorite.IsActive = false;

            _dbContext.Update(favorite);
            _dbContext.SaveChanges();

            return new ResultModel<object>(data: favorite, message: "The favorite has been removed");
        }

        public ResultModel<object> GetFavoriteListByUserId(Guid userId)
        {
            var favoriteList = _dbContext.Favorites
                .Where(com => com.UserId == userId)
                .Where(com => com.IsActive)
                .OrderBy(com => com.Created)
                .ToList();
            
            return new ResultModel<object>(data : favoriteList);
        }
    }
}