using System.Collections.Generic;
using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Boundaries.Persistence;

/// <summary>
/// Provides the contract to provide methods to interact with Asegurados.
/// </summary>
public interface IAseguradosRepositoryDummy
{
    /// <summary>Get all rests service definition for a repository</summary>
    /// <returns></returns>
    ICollection<Asegurado> Retrieve();

    /// <summary>
    /// Gets asegurado by id.
    /// </summary>
    /// <param name="id"> Property id.</param>
    /// <returns>An instance of <see cref="Asegurado"/></returns>
    Asegurado GetAseguradoById(Guid id);
    
    /// <summary>
    /// Persist a given asegurado.
    /// </summary>
    /// <param name="asegurado">Property to be persisted.</param>
    void Save(Asegurado asegurado);
}