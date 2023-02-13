using System.Collections.Generic;
using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Boundaries.Persistence;

/// <summary>
/// Provides the contract to provide methods to interact with Owners.
/// </summary>
public interface IOwnerRepositoryDummy
{
    /// <summary>
    /// Saves owner.
    /// </summary>
    /// <param name="owner">Represents an owner.</param>
    void Save(Owner owner);
    
    /// <summary>
    /// Gets all owners and its properties.
    /// </summary>
    /// <returns></returns>
    ICollection<Owner> Retrieve();
    
}