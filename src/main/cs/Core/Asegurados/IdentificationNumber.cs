namespace RI.Novus.Core.Asegurados;

/// <summary>
/// Represents an asegurado's identification number.
/// </summary>
public sealed class IdentificationNumber : ICoreDomainPrimitive<string>,
IEquatable<IdentificationNumber>, IComparable<IdentificationNumber>
{
/// <summary>
/// Minimum allowed length.
/// </summary>
public const int MinLength = 7;

/// <summary>
/// Maximum allowed length.
/// </summary>
public const int MaxLength = 11;

private readonly ConfigurableString _innerValue;

/// <summary>
/// Validates raw asegurado's identification number and creates a valid instance or throw exceptions.
/// </summary>
/// <param name="rawIdentificationNumber">Raw asegurado's identification number.</param>
public IdentificationNumber(string rawIdentificationNumber)
{
    Message genericMessage = new("Invalid value or format for asegurado IdentificationNumber.");
    ConfigurableString.Builder builder = new(genericMessage, useSingleMessage: true);

    StringLengthRange range = new(new StringLength(MinLength), new StringLength(MaxLength));

    builder.WithRequiresTrimmed()
           .WithLengthRange(range, genericMessage, genericMessage)
           .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase);

    _innerValue = builder.Build(rawIdentificationNumber);

}

/// <inheritdoc cref="ICoreDomainPrimitive{TRawType}.Value"/>
public string Value => _innerValue.Value;

/// <summary>
/// Compare values using <see cref="StringComparison.OrdinalIgnoreCase"/> strategy.
/// </summary>
/// <param name="other">Represents the other instance to compare.</param>
/// <returns></returns>
public int CompareTo(IdentificationNumber? other)
    => RelationalOperatorsOverloadHelper.SelfComparedToOther(this, other,
        o => _innerValue.CompareTo(o._innerValue));

/// <inheritdoc cref="ConfigurableString.Equals(object?)"/>
public override bool Equals(object? obj)
    => Equals(obj as IdentificationNumber);

/// <inheritdoc cref="ConfigurableString.Equals(ConfigurableString?)"/>
public bool Equals(IdentificationNumber? other)
    => RelationalOperatorsOverloadHelper.SelfIsEqualsTo(this, other, o => _innerValue.Equals(o._innerValue));

/// <inheritdoc cref="ConfigurableString.GetHashCode"/>
public override int GetHashCode() => _innerValue.GetHashCode();

/// <summary>
/// Same as <see cref="Value"/>.
/// </summary>
/// <returns></returns>
public override string ToString() => Value;

/// <summary>
/// Tries to create an instance from the raw identification name.
/// </summary>
/// <param name="identificationNumber">Represents the created instance.</param>
/// <returns></returns>
public static IdentificationNumber From(string identificationNumber)
    => new(identificationNumber);

#region Relational Operators

/// <summary>
/// Indicates if two instances are not equal.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator !=(IdentificationNumber left, IdentificationNumber right)
    => RelationalOperatorsOverloadHelper.NotEquals(left, right);

/// <summary>
/// Indicates if two instances are equals.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator ==(IdentificationNumber left, IdentificationNumber right)
    => RelationalOperatorsOverloadHelper.Equals(left, right);

/// <summary>
/// Indicates if <paramref identificationNumber="left"/> is less than <paramref identificationNumber="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator <(IdentificationNumber left, IdentificationNumber right)
    => RelationalOperatorsOverloadHelper.LessThan(left, right);

/// <summary>
/// Indicates if <paramref identificationNumber="left"/> is less than or equals to <paramref identificationNumber="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator <=(IdentificationNumber left, IdentificationNumber right)
    => RelationalOperatorsOverloadHelper.LessThanOrEqualsTo(left, right);

/// <summary>
/// Indicates if <paramref identificationNumber="left"/> is greater than <paramref identificationNumber="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator >(IdentificationNumber left, IdentificationNumber right)
    => RelationalOperatorsOverloadHelper.GreaterThan(left, right);

/// <summary>
/// Indicates if <paramref identificationNumber="left"/> is greater than or equals to <paramref identificationNumber="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator >=(IdentificationNumber left, IdentificationNumber right)
    => RelationalOperatorsOverloadHelper.GreaterThanOrEqualsTo(left, right);

#endregion //Relational Operators Overload
}
