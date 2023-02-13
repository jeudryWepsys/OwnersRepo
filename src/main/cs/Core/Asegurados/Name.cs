namespace RI.Novus.Core.Asegurados;

/// <summary>
/// Represents an asegurado's name.
/// </summary>
public sealed class Name : ICoreDomainPrimitive<string>,
IEquatable<Name>, IComparable<Name>
{
/// <summary>
/// Minimum allowed length.
/// </summary>
public const int MinLength = 4;

/// <summary>
/// Maximum allowed length.
/// </summary>
public const int MaxLength = 20;

private readonly ConfigurableString _innerValue;

/// <summary>
/// Validates raw asegurado's name and creates a valid instance or throw exceptions.
/// </summary>
/// <param name="rawName">Represents the raw asegurado's name.</param>
public Name(string rawName)
{
    Message genericMessage = new("Invalid value or format for asegurado Name.");
    ConfigurableString.Builder builder = new(genericMessage, useSingleMessage: true);

    StringLengthRange range = new(new StringLength(MinLength), new StringLength(MaxLength));

    builder.WithRequiresTrimmed()
           .WithLengthRange(range, genericMessage, genericMessage)
           .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase);

    _innerValue = builder.Build(rawName);

}

/// <inheritdoc cref="ICoreDomainPrimitive{TRawType}.Value"/>
public string Value => _innerValue.Value;

/// <summary>
/// Compare values using <see cref="StringComparison.OrdinalIgnoreCase"/> strategy.
/// </summary>
/// <param name="other">Represents the other instance to compare.</param>
/// <returns></returns>
public int CompareTo(Name? other)
    => RelationalOperatorsOverloadHelper.SelfComparedToOther(this, other,
        o => _innerValue.CompareTo(o._innerValue));

/// <inheritdoc cref="ConfigurableString.Equals(object?)"/>
public override bool Equals(object? obj)
    => Equals(obj as Name);

/// <inheritdoc cref="ConfigurableString.Equals(ConfigurableString?)"/>
public bool Equals(Name? other)
    => RelationalOperatorsOverloadHelper.SelfIsEqualsTo(this, other, o => _innerValue.Equals(o._innerValue));

/// <inheritdoc cref="ConfigurableString.GetHashCode"/>
public override int GetHashCode() => _innerValue.GetHashCode();

/// <summary>
/// Same as <see cref="Value"/>.
/// </summary>
/// <returns></returns>
public override string ToString() => Value;

/// <summary>
/// Tries to create an instance from the rawName.
/// </summary>
/// <param name="name">Represents the rawName.</param>
/// <returns></returns>
public static Name From(string name)
    => new(name);

#region Relational Operators

/// <summary>
/// Indicates if two instances are not equal.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator !=(Name left, Name right)
    => RelationalOperatorsOverloadHelper.NotEquals(left, right);

/// <summary>
/// Indicates if two instances are equals.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator ==(Name left, Name right)
    => RelationalOperatorsOverloadHelper.Equals(left, right);

/// <summary>
/// Indicates if <paramref name="left"/> is less than <paramref name="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator <(Name left, Name right)
    => RelationalOperatorsOverloadHelper.LessThan(left, right);

/// <summary>
/// Indicates if <paramref name="left"/> is less than or equals to <paramref name="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator <=(Name left, Name right)
    => RelationalOperatorsOverloadHelper.LessThanOrEqualsTo(left, right);

/// <summary>
/// Indicates if <paramref name="left"/> is greater than <paramref name="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator >(Name left, Name right)
    => RelationalOperatorsOverloadHelper.GreaterThan(left, right);

/// <summary>
/// Indicates if <paramref name="left"/> is greater than or equals to <paramref name="right"/>.
/// </summary>
/// <param name="left">Represents the left instance.</param>
/// <param name="right">Represents the right instance.</param>
/// <returns></returns>
public static bool operator >=(Name left, Name right)
    => RelationalOperatorsOverloadHelper.GreaterThanOrEqualsTo(left, right);

#endregion //Relational Operators Overload
}
