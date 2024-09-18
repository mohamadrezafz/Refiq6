using Microsoft.EntityFrameworkCore;
using Refiq6.Application.Interfaces;
using Refiq6.Domain.Entities;
using System.Reflection;


namespace Refiq6.Infrastructure.Persistance;

public class ApplicationDatabaseContext : DbContext , IApplicationDatabaseContext
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<Quiz> Quizes { get; set; }
    public DbSet<Option> Options { get; set; }


    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
    {
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)=>
        await base.SaveChangesAsync(cancellationToken);
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Apply entity configurations from the current assembly
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
