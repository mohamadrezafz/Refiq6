using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refiq6.Domain.Entities;

namespace Refiq6.Infrastructure.Persistance.Configurations;

public class QuizConfiguration
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.AuthorName).IsRequired();

    }
}
