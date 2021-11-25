using System;

namespace hey_istanbul_backend.Data
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        
    }
}