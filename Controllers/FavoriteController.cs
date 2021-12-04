using System;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Favorites;
using hey_istanbul_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hey_istanbul_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FavoriteController : BaseController
    {
        private IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService ){
            _favoriteService = favoriteService;
        }

        [HttpPost("CreateFavorite")]
        ResultModel<object> CreateFavorite(CreateFavoriteRequest request){
            request.UserId = this.GetActiveUserId();
            return _favoriteService.CreateFavorite(request);
        }

        [HttpPost("DeleteFavorite/{favoriteId}")]
        ResultModel<object> DeleteFavorite(Guid favoriteId){
            return _favoriteService.DeleteFavorite(favoriteId, this.GetActiveUserId());
        }

        [HttpGet("GetFavorites")]
        ResultModel<object> GetFavorites(){
            return _favoriteService.GetFavoriteListByUserId(this.GetActiveUserId());
        }
    }
}