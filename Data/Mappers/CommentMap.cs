using hey_istanbul_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hey_istanbul_backend.Mappers
{
    public class CommentMap : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).IsRequired(true);
            builder.Property(x => x.Created).IsRequired(true);
            builder.Property(x => x.LocationId).IsRequired(true);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.HasOne(x => x.User).WithMany(u => u.Comments).HasForeignKey(x => x.UserId);
        }
    }
}
