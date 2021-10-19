using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Mapping
{
    [ExcludeFromCodeCoverage]
    public class PetMapConfig : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets");

            builder.Property("Id")
                   .UseIdentityColumn();

            builder.Property(u => u.UserId)
                   .IsRequired();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Specie)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(u => u.Breed)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(u => u.AgeYears)
                   .IsRequired()
                   .HasMaxLength(5);

            builder.Property(u => u.AgeMonths)
                   .IsRequired()
                   .HasMaxLength(5);

            builder.Property(u => u.Size)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(u => u.Adopted)
                   .IsRequired();

            builder.Property(u => u.Description)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.HasOne(u => u.PetPhoto)
                   .WithOne(x => x.Pet);
        }
    }
}
