using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("BIGINT");
            
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(120)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Password")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("Cpf")
                .HasColumnType("CHAR(11)");
        }
    }
}