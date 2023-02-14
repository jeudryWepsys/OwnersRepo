using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerCodiaFacts;

/// <summary>
/// Tests for <see cref="Codia.AsPrimitive" />.
/// </summary>
[TestFixture]
public sealed class AsPrimitiveMessageFacts
{
    /// <summary>
    /// Returns wrapped value using <see cref="Codia.From" />.
    /// </summary>
    /// <param name="wrappedValue"> Represents the wrapped value. </param>
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_From(int wrappedValue)
    {
        Codia codia = Codia.From(wrappedValue);

        Assert.That(codia.AsPrimitive, Is.EqualTo(wrappedValue));
    }

    /// <summary>
    /// Returns wrapped value using <see cref="Codia.From" />.
    /// </summary>
    /// <param name="wrappedValue">Represents the wrapped value.</param>
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_Constructor(int wrappedValue)
    {
        Codia codia = Codia.From(wrappedValue);

        Assert.That(codia.AsPrimitive, Is.EqualTo(wrappedValue));
    }
}
