using System;
using System.ComponentModel.DataAnnotations;

namespace hey_istanbul_backend.Data.Entities
{
    public class CommentEntity : BaseEntity
    {
        public string LocationId {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public UserEntity User {get; set;}
        public Guid UserId { get; set; }
    }
}