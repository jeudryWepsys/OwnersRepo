namespace RI.Novus.Core.Asegurados;

/// <summary>Form unique ID.</summary>
public sealed class Id : AbstractGuidBasedIdPrimitive
{
    /// <summary>Creates a new instance with a random <see cref="Guid"/>.</summary>
    /// <returns></returns>
    public static Id Generate() => new(Guid.NewGuid());

    /// <summary>
    /// Builds an id or throws an exception
    /// </summary>
    /// <param name="rawValue">Represents the raw value of the id</param>
    public static Id From(Guid rawValue) => new(rawValue);

    private Id(Guid rawValue) : base(rawValue)
    {
    }
    
    private Id() : this(Guid.NewGuid())
    {
    }
}