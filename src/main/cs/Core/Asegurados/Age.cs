namespace RI.Novus.Core.Asegurados;

/// <summary>
/// Represent asegurado's age.
/// </summary>
public sealed class Age : AbstractPositiveIntegerPrimitive
{
    private static readonly PositiveInteger MinValue = new(1);
    private static readonly PositiveInteger MaxValue = new(130);

    /// <summary>
    ///  Validates input and sets the corresponding property.
    /// </summary>
    /// <param name="rawValue">Represents the raw value of Age.</param>
    public Age(PositiveInteger rawValue) : base(rawValue, MinValue, MaxValue)
    {
    }
    
    /// <summary>
    /// Creates an instance using current system time as UTC.
    /// </summary>
    /// <param name="age">Age value.</param>
    /// <returns></returns>
    public static Age From(int age)
        => new(new PositiveInteger(age));
}