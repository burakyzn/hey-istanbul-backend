using hey_istanbul_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hey_istanbul_backend.Mappers
{
    public class FavoriteMap : IEntityTypeConfiguration<FavoriteEntity>
    {
        public void Configure(EntityTypeBuilder<FavoriteEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).IsRequired(true);
            builder.Property(x => x.Created).IsRequired(true);
            builder.Property(x => x.LocationId).IsRequired(true);
            builder.HasOne(x => x.User).WithMany(u => u.Favorites).HasForeignKey(x => x.UserId);
            builder.Property(x => x.Title).IsRequired(true).HasDefaultValue("İsimsiz Mekan");
        }
    }
}