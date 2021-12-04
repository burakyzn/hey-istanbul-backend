using System;
using System.Collections.Generic;

namespace hey_istanbul_backend.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<FavoriteEntity> Favorites { get; set; }
    }
}