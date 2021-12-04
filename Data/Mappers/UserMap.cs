using hey_istanbul_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hey_istanbul_backend.Mappers
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).IsRequired(true);
            builder.Property(x => x.Created).IsRequired(true);
            builder.Property(x => x.Nickname).IsRequired(true);
            builder.Property(x => x.Password).IsRequired(true);
        }
    }
}