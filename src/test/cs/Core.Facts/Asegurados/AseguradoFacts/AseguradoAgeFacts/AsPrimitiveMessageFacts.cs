using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoAgeFacts;

/// <summary>
/// Tests for <see cref="Age.AsPrimitive" />.
/// </summary>
[TestFixture]
public sealed class AsPrimitiveMessageFacts
{
    /// <summary>
    /// Returns wrapped value using <see cref="Age.From" />.
    /// </summary>
    /// <param name="wrappedValue"> Represents the wrapped value. </param>
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_From(int wrappedValue)
    {
        Age age = Age.From(wrappedValue);

        Assert.That(age.AsPrimitive, Is.EqualTo(wrappedValue));
    }

    /// <summary>
    /// Returns wrapped value using <see cref="Age.From" />.
    /// </summary>
    /// <param name="wrappedValue">Represents the wrapped value.</param>
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_Constructor(int wrappedValue)
    {
        Age age = Age.From(wrappedValue);

        Assert.That(age.AsPrimitive, Is.EqualTo(wrappedValue));
    }
}
