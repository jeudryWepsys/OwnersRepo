namespace RI.Novus.Core.Inmovable.Properties;

///<summary>Represents Property's Area</summary>
public sealed class Area : ICoreDomainPrimitive<decimal>
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
    /// Shortcut for constructor <see cref="Area"/>.
    /// <param name="area">Represents a area.</param>
    /// <returns>An instance of <see cref="Area"/></returns>
    /// </summary>
    public static Area From(decimal area) => new(area);

    /// <summary>
    /// Creates new instances for this class.
    /// </summary>
    /// <param name="rawArea"></param>
    public Area(decimal rawArea)
        => Value = Arguments.Between(rawArea, MinValue, MaxValue, nameof(rawArea), "Invalid value or format for Property's Area");

    /// <summary>
    /// Gets area value
    /// </summary>
    public decimal Value { get; }
}