using RI.Novus.Core.Inmovable.Owners;
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
    /// <param name="owner">Represents an owner.</param>
    /// <param name="propertyId">Represents the property id.</param>
    void Delete(Owner owner, Guid propertyId);

    /// <summary>
    /// Updates owner's properties.
    /// </summary>
    /// <param name="owner">Represents an owner.</param>
    /// <param name="propertyId">Represents the property id.</param>
    /// <param name="propertyToUpdate"></param>
    void Update(Owner owner, Guid propertyId, Property propertyToUpdate);
}