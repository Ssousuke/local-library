using LocalLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalLibrary.Infra.Data.EntityConfig
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Summary).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ISBN).HasMaxLength(13).IsRequired();

            builder.HasOne(x => x.Author)
                   .WithMany(p => p.Books)
                   .HasForeignKey(x => x.AuthorId);

            builder.HasOne(x => x.Genre)
                   .WithMany(p => p.Books)
                   .HasForeignKey(x => x.GenreId);

            builder.HasOne(x => x.Language)
                   .WithMany(p => p.Books)
                   .HasForeignKey(x => x.LanguageId);
        }
    }
}
