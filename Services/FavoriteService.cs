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
            var favorite = _dbContext.Favorites
                .Where(fav => fav.LocationId == request.LocationId)
                .Where(fav => fav.UserId == request.UserId)
                .Where(fav => fav.IsActive)
                .SingleOrDefault();

            if(favorite != null)
                return new ResultModel<object>(data: favorite, message: "The favorite has already created.");

            FavoriteEntity newFavorite = new FavoriteEntity{
                LocationId = request.LocationId,
                UserId = request.UserId,
                Title = request.Title
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
                .Where(fav => fav.UserId == userId)
                .Where(fav => fav.IsActive)
                .OrderBy(fav => fav.Created)
                .Select(fav => new {
                    fav.Id,
                    fav.LocationId,
                    fav.Title,
                    fav.Created
                })
                .ToList();
            
            return new ResultModel<object>(data : favoriteList);
        }

        public ResultModel<object> IsFavorite(string locationId, Guid userId)
        {
            var favorite = _dbContext.Favorites
                .Where(fav => fav.LocationId == locationId)
                .Where(fav => fav.UserId == userId)
                .Where(fav => fav.IsActive)
                .SingleOrDefault();

            return new ResultModel<object>(data: new {
                    IsAlreadyFavorite = favorite != null
                });
        }
    }
}