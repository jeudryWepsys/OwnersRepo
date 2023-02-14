using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Owners;
using Triplex.Validations;

namespace Persistence;

/// <summary>
/// Represents a repository for the <see cref="Owner"/> entity.
/// </summary>
public sealed class OwnerRepository: IOwnerRepository
{
    private readonly RINovusContext _context;
    
    /// <summary>
    /// Creates a new instance of <see cref="OwnerRepository"/>.
    /// </summary>
    /// <param name="context">The database context.</param>
    public OwnerRepository(RINovusContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Saves the given <paramref name="owner"/> to the database.
    /// </summary>
    /// <param name="owner">The owner to save.</param>
    public void Save(Owner owner)
    {
        OwnerPM ownerDatabaseModel = OwnerPM.FromEntity(owner);
        _context.Owners.Add(ownerDatabaseModel);
        _context.Properties.AddRange(owner.Properties.Select(PropertyPM.FromEntity));
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Retrieves all the owners from the database.
    /// </summary>
    /// <returns></returns>
    public ICollection<Owner> Retrieve()
    {
        List<Owner> owners = new List<Owner>();
        List<OwnerPM> ownersDatabaseModel = _context.Owners.AsNoTracking().Include(x => x.Properties).ToList();
        
        foreach (var i in ownersDatabaseModel)
        {
            owners.Add(i.ToEntity());
        }
        
        return owners;
    }
    
    /// <summary>
    /// Gets the given <paramref name="ownerId"/> to the database.
    /// </summary>
    /// <param name="ownerId">The id of the property to save.</param>
    /// <returns></returns>
    public Owner GetOwnerById(Guid ownerId)
    {
        OwnerPM owner = _context.Owners.AsNoTracking().Include(x => x.Properties).FirstOrDefault(x => x.Id == ownerId);
        Arguments.NotNull(owner, nameof(owner));
        
        return owner.ToEntity();
    }

    bool IOwnerRepository.Exists(IdentificationNumber identificationNumber)
    {
        string rawName = identificationNumber.Value;

        return _context.Owners.AsNoTracking().Any(owner => owner.Name == rawName);
    }
}