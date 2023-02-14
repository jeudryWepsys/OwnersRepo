namespace RI.Novus.Core.Inmovable.Owners;

/// <summary>
/// Represent owner's codia.
/// </summary>
public sealed class Codia : AbstractPositiveIntegerPrimitive
{
    private static readonly PositiveInteger MinValue = new(1);
    private static readonly PositiveInteger MaxValue = new(int.MaxValue);

    /// <summary>
    ///  Validates input and sets the corresponding property.
    /// </summary>
    /// <param name="rawValue">Represents the raw value of Codia.</param>
    public Codia(PositiveInteger rawValue) : base(rawValue, MinValue, MaxValue)
    {
    }
    
    /// <summary>
    /// Creates an instance using current system time as UTC.
    /// </summary>
    /// <param name="codia">Codia value.</param>
    /// <returns></returns>
    public static Codia From(int codia)
        => new(new PositiveInteger(codia));
}