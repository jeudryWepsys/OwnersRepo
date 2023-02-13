using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;

namespace Persistence;

/// <summary>
/// Represents the context for the RINovus database.
/// </summary>
public sealed class RINovusContext : DbContext
{
    /// <summary>
    /// Indicates which is the default schema for bpn.
    /// </summary>
    public const string DefaultSchema = "RINovus";

    /// <summary>
    /// Initializes a new instance of the <see cref="RINovusContext"/> class.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public RINovusContext(DbContextOptions<RINovusContext> options) :
        base(options)
    {
        Owners = Set<OwnerPM>();
        Properties = Set<PropertyPM>();
    }

    /// <inheritdoc cref="DbContext.OnModelCreating"/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RINovusContext).Assembly);
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<OwnerPM>()
            .HasMany(x => x.Properties)
            .WithOne(x => x.PropertyOwner)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    /// <summary>
    /// <see cref="Owners"/> collection.
    /// </summary>
    public DbSet<OwnerPM> Owners { get; set; }

    /// <summary>
    /// <see cref="Properties"/> collection.
    /// </summary>
    public DbSet<PropertyPM> Properties { get; set; }
}
   