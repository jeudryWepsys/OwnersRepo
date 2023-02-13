using RI.Novus.Core.Inmovable.Properties;

namespace RI.Novus.Core.Boundaries.Persistence;

/// <summary>
/// Provides the contract to provide methods to interact with Owners.
/// </summary>
public interface IPropertyRepositoryDummy
{
    /// <summary>
    /// Saves property.
    /// </summary>
    /// <param name="propertyId">Represents the property id.</param>
    /// <returns></returns>
    Property GetPropertyById(Guid propertyId);

    /// <summary>
    /// Deletes property.
    /// </summary>
    /// <param name="propertyId">Represents the property id.</param>
    void DeleteProperty(Guid propertyId);
    
    /// <summary>
    /// Updates all properties.
    /// </summary>
    /// <param name="propertyId">Represents the property id.</param>
    /// <param name="property">Represents the property.</param>
    void UpdateProperty(Guid propertyId, Property property);
}