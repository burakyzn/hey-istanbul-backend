using System;

namespace hey_istanbul_backend.Data.Entities
{
    public class FavoriteEntity : BaseEntity
    {
        public string LocationId {get; set;}
        public UserEntity User {get; set;}
        public Guid UserId { get; set; }
    }
}