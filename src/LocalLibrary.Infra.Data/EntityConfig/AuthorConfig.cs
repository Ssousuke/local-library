using LocalLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalLibrary.Infra.Data.EntityConfig
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.Name).HasMaxLength(75).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.DateOfDeath);
        }
    }
}
