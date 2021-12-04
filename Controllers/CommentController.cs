using System;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Comments;
using hey_istanbul_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hey_istanbul_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommentController : BaseController
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService ){
            _commentService = commentService;
        }

        [HttpPost("CreateComment")]
        public ResultModel<object> CreateComment(CreateCommentRequest request){
            request.UserId = this.GetActiveUserId();
            return _commentService.CreateComment(request);
        }

        [HttpPost("DeleteComment/{commentId}")]
        public ResultModel<object> DeleteComment(Guid commentId){
            return _commentService.DeleteComment(commentId, this.GetActiveUserId());
        }

        [HttpGet("GetCommentByLocationId/{locationId}")]
        public ResultModel<object> DeleteComment(string locationId){
            return _commentService.GetCommentByLocationId(locationId);
        }

        [HttpGet("GetComments")]
        public ResultModel<object> GetComments(){
            return _commentService.GetCommentListByUserId(this.GetActiveUserId());
        }
    }
}