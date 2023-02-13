namespace RI.Novus.Core.Inmovable.Properties;

///<summary>Represents Property's Region</summary>
public sealed class Region : ICoreDomainPrimitive<decimal>
{
    /// <summary>
    /// As primitive types are inlined by the compiler the coverlet tool does not catch a hit for 
    /// lines `private const decimal MinValue = 0.01M; and MaxValue.
    /// </summary>
#pragma warning disable CA1802 //Field 'xxx' is 'readonly' but initialized with constant value. Use 'const' instead.
    private static readonly decimal MinValue = 0.01M;
    private static readonly decimal MaxValue = 99_999M;

#pragma warning restore CA1802 //Field 'xxx' is 'readonly' but initialized with constant value. Use 'const' instead.

    /// <summary>
    /// Shortcut for constructor <see cref="Region"/>.
    /// <param name="region">Represents a region.</param>
    /// <returns>An instance of <see cref="Region"/></returns>
    /// </summary>
    public static Region From(decimal region) => new(region);

    /// <summary>
    /// Creates a new instance of <see cref="Region"/>
    /// </summary>
    /// <param name="rawRegion"></param>
    public Region(decimal rawRegion)
        => Value = Arguments.Between(rawRegion, MinValue, MaxValue, nameof(rawRegion), "Invalid value or format for Property's Region");

    /// <summary>
    /// Gets region value
    /// </summary>
    public decimal Value { get; }
}