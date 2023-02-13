namespace RI.Novus.Core.Asegurados;

/// <summary>
/// Indicates the birthday for an asegurado.
/// </summary>
public sealed class Birthday : AbstractPastOrPresentTimestampPrimitive
{
     
    /// <summary>Shortcut for birthdate of asegurado.</summary>
    /// <param name="dateTimeOffset">Represents the raw value of Birthday.</param>
    /// <returns></returns>
    public static Birthday From(DateTimeOffset dateTimeOffset) => new(new PastOrPresentTimestamp(dateTimeOffset));
    
    /// <summary>
    /// Creates new instances for this class.
    /// </summary>
    /// <param name="rawTimestamp">Can not be <see langword="null"/></param>
    public Birthday(PastOrPresentTimestamp rawTimestamp) : base(rawTimestamp)
    {
    }
}