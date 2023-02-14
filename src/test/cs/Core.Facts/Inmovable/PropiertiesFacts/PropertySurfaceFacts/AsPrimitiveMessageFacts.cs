

using RI.Novus.Core.Inmovable.Properties;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.PropertySurfaceFacts;

/// <summary>
/// Tests for <see cref="Surface.AsPrimitive" />.
/// </summary>
[TestFixture]
public sealed class AsPrimitiveMessageFacts
{
    /// <summary>
    /// Returns wrapped value using <see cref="Surface.From" />.
    /// </summary>
    /// <param name="wrappedValue"> Represents the wrapped value. </param>
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_From(int wrappedValue)
    {
        Surface codia = Surface.From(wrappedValue);

        Assert.That(codia.Value, Is.EqualTo(wrappedValue));
    }

    /// <summary>
    /// Returns wrapped value using <see cref="Surface.From" />.
    /// </summary>
    /// <param name="wrappedValue">Represents the wrapped value.</param>
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_Constructor(int wrappedValue)
    {
        Surface codia = Surface.From(wrappedValue);

        Assert.That(codia.Value, Is.EqualTo(wrappedValue));
    }
}
