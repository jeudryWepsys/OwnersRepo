using Persistence.Models;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;

namespace Persistence;

/// <summary>
/// Represents a repository for the <see cref="Property"/> entity.
/// </summary>
public sealed class PropertyRepository: IPropertyRepositoryDummy
{
    private readonly RINovusContext _context;
    
    /// <summary>
    /// Creates a new instance of <see cref="PropertyRepository"/>.
    /// </summary>
    /// <param name="context">The database context.</param>
    public PropertyRepository(RINovusContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Delete owner's property.
    /// </summary>
    /// <param name="owner">Represents an owner.</param>
    /// <param name="propertyId">Represents the property id.</param>
    public void Delete(Owner owner, Guid propertyId)
    {
        OwnerPM propertyOwner = OwnerPM.FromEntity(owner);
        PropertyPM propertyToDelete =
            _context.Properties.FirstOrDefault(x => x.Id == propertyId && x.OwnerId == propertyOwner.Id);
        if (propertyToDelete != null) _context.Properties.Remove(propertyToDelete);
        _context.SaveChanges();
    }

    /// <summary>
    /// Updates owner's property.
    /// </summary>
    /// <param name="owner">Represents an owner.</param>
    /// <param name="propertyId">Represents the property id.</param>
    /// <param name="propertyToUpdate">Represents the property to update.</param>
    public void Update(Owner owner, Guid propertyId, Property propertyToUpdate)
    {
        OwnerPM propertyOwner = OwnerPM.FromEntity(owner);
        PropertyPM propertyUpdate =
            _context.Properties.FirstOrDefault(x => x.Id == propertyId && x.OwnerId == propertyOwner.Id);
        if (propertyUpdate != null)
        {
            PropertyPM ownerProperty = PropertyPM.FromEntity(propertyToUpdate);
            propertyUpdate.Surface = ownerProperty.Surface;
            propertyUpdate.Type = ownerProperty.Type;
            propertyUpdate.Area = ownerProperty.Area;
            propertyUpdate.Region = ownerProperty.Region;
            _context.SaveChanges();
        }
    }
}