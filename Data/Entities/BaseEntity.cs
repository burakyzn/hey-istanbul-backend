using System;

namespace hey_istanbul_backend.Data.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}