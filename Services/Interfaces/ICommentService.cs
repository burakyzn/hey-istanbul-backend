using System;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Comments;

namespace hey_istanbul_backend.Services.Interfaces
{
    public interface ICommentService
    {
        ResultModel<object> GetCommentByLocationId(string locationId);
        ResultModel<object> GetCommentByUserId(Guid userId);
        ResultModel<object> CreateComment(CreateCommentRequest request);
        ResultModel<object> DeleteComment(Guid commentId, Guid userId);
    }
}