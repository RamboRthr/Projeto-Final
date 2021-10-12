using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Id)
                   .UseIdentityColumn();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Surname)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Cpf)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Phone)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Street)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.HouseNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.District)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(u => u.Cep)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.BirthDate)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(u => u.Pets)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
