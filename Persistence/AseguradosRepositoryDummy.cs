using System.Collections.ObjectModel;
using RI.Novus.Core.Boundaries.Persistence;
using Asegurado = Persistence.Models.Asegurado;

namespace Persistence;

/// <summary>
/// Represents the dummy in memory implementation for Asegurados.
/// </summary>
public sealed class AseguradosRepositoryDummy : IAseguradosRepositoryDummy
{
    private static ICollection<Asegurado> _asegurados = new List<Asegurado>
    {
        new (Guid.NewGuid(),"Asegurado1", "40213479476", DateTimeOffset.Now, 20),
        new (Guid.NewGuid(),"Asegurado2", "40213479477", DateTimeOffset.Now, 26),
    };

    /// <inheritdoc />
    ICollection<RI.Novus.Core.Asegurados.Asegurado> IAseguradosRepositoryDummy.Retrieve()
    {
        return new ReadOnlyCollection<RI.Novus.Core.Asegurados.Asegurado>(_asegurados.Select(asegurado => asegurado.ToEntity()).ToList());
    }

    /// <inheritdoc />
    public RI.Novus.Core.Asegurados.Asegurado GetAseguradoById(Guid id)
    {
        Asegurado asegurado = _asegurados.FirstOrDefault(asegurado => asegurado.Id == id) ?? throw new InvalidOperationException();
        return asegurado.ToEntity();
    }

    /// <inheritdoc />
    public void Save(RI.Novus.Core.Asegurados.Asegurado asegurado)
    {
        var aseguradoDatabaseModel = Asegurado.FromEntity(asegurado);
        
        _asegurados.Add(aseguradoDatabaseModel);
    }
}

