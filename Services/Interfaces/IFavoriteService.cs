using System;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Favorites;

namespace hey_istanbul_backend.Services.Interfaces
{
    public interface IFavoriteService
    {
        ResultModel<object> GetFavoriteListByUserId(Guid userId);
        ResultModel<object> CreateFavorite(CreateFavoriteRequest request);
        ResultModel<object> DeleteFavorite(Guid favoriteId, Guid userId);
    }
}