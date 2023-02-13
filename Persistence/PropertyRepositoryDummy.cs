using Persistence.Models;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Properties;

namespace Persistence;

/// <summary>
/// Dummy implementation of <see cref="IPropertyRepositoryDummy"/> that uses an in-memory database.
/// </summary>
public sealed class PropertyRepositoryDummy: IPropertyRepositoryDummy
{
    private readonly RINovusContext _context;
    
    /// <summary>
    /// Creates a new instance of <see cref="PropertyRepositoryDummy"/>.
    /// </summary>
    /// <param name="context">The database context.</param>
    public PropertyRepositoryDummy(RINovusContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Gets the given <paramref name="propertyId"/> to the database.
    /// </summary>
    /// <param name="propertyId">The id of the property to save.</param>
    /// <returns></returns>
    public Property GetPropertyById(Guid propertyId)
    {
        var property = _context.Properties.Find(propertyId);
        return property.ToEntity();
    }

    /// <summary>
    /// Delete the property from the database.
    /// </summary>
    /// <param name="propertyId"> The id of the property to delete.</param>
    public void DeleteProperty(Guid propertyId)
    {
        var propertyToDelete = _context.Properties.Find(propertyId);
        if (propertyToDelete != null) _context.Properties.Remove(propertyToDelete);
        _context.SaveChanges();
    }

    /// <summary>
    /// Updates all the properties from the database.
    /// </summary>
    /// <param name="propertyId">The id of the property to update.</param>
    /// <param name="property">The property to update.</param>
    public void UpdateProperty(Guid propertyId, Property property)
    {
        var ownerProperty = PropertyPM.FromEntity(property);
        var propertyToUpdate = _context.Properties.Find(propertyId);
        if (propertyToUpdate != null)
        {
            propertyToUpdate.OwnerId = ownerProperty.OwnerId;
            propertyToUpdate.Surface = ownerProperty.Surface;
            propertyToUpdate.Type = ownerProperty.Type;
            propertyToUpdate.Area = ownerProperty.Area;
            propertyToUpdate.Region = ownerProperty.Region;
            _context.SaveChanges();
        }
    }
}