

using Refiq6.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Refiq6.Application.Interfaces;

public interface IApplicationDatabaseContext 
{
    public DbSet<Question> Questions { get; }
    public DbSet<Quiz> Quizes { get; }
    public DbSet<Option> Options { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
