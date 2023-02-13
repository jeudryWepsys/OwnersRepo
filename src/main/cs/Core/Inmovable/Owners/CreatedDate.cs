namespace RI.Novus.Core.Inmovable.Owners;

/// <summary>
/// Indicates the created date for an owner.
/// </summary>
public sealed class CreatedDate : AbstractPastOrPresentTimestampPrimitive
{
    
    /// <summary>Creates an instance using current system time as UTC.</summary>
    /// <returns></returns>
    public static CreatedDate Now() => CreatedDate.From(DateTimeOffset.UtcNow);
     
    /// <summary>Shortcut for created date of owner.</summary>
    /// <param name="dateTimeOffset"> Represents the raw value of Created Date.</param>
    /// <returns></returns>
    public static CreatedDate From(DateTimeOffset dateTimeOffset) => new(new PastOrPresentTimestamp(dateTimeOffset));
    
    /// <summary>
    /// Creates new instances for this class.
    /// </summary>
    /// <param name="rawTimestamp">Can not be <see langword="null"/></param>
    public CreatedDate(PastOrPresentTimestamp rawTimestamp) : base(rawTimestamp)
    {
    }
}