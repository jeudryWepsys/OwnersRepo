using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;
using Triplex.Validations;

namespace Persistence;

/// <summary>
/// Dummy implementation of <see cref="IOwnerRepositoryDummy"/> that uses an in-memory database.
/// </summary>
public sealed class OwnerRepositoryDummy: IOwnerRepositoryDummy
{
    private readonly RINovusContext _context;
    
    /// <summary>
    /// Creates a new instance of <see cref="OwnerRepositoryDummy"/>.
    /// </summary>
    /// <param name="context">The database context.</param>
    public OwnerRepositoryDummy(RINovusContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Saves the given <paramref name="owner"/> to the database.
    /// </summary>
    /// <param name="owner">The owner to save.</param>
    public void Save(Owner owner)
    {
        var ownerDatabaseModel = OwnerPM.FromEntity(owner);
        _context.Owners.Add(ownerDatabaseModel);
        
        /*foreach (var i in owner.Properties)
        {
            _context.Properties.Add(PropertyPM.FromEntity(i));
        }*/
        _context.Properties.AddRange(owner.Properties.Select(PropertyPM.FromEntity));
        
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Retrieves all the owners from the database.
    /// </summary>
    /// <returns></returns>
    public ICollection<Owner> Retrieve()
    {
        var owners = new List<Owner>();
        var ownersDatabaseModel = _context.Owners.Include(x => x.Properties).ToList();
        
        foreach (var i in ownersDatabaseModel)
        {
            owners.Add(i.ToEntity(i.Properties));
        }
        
        return owners;
    }
}