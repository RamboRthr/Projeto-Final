using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class PhotoMapConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");

            builder.Property("Id")
                   .UseIdentityColumn();

            builder.Property(u => u.PetId)
                   .IsRequired();

            builder.Property(u => u.PhotoPath)
                   .IsRequired();

        }
    }
}
