using RI.Novus.Core.Inmovable.Properties;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.PropertySurfaceFacts;

[TestFixture]
internal sealed class FromMessageFacts
{
    private static readonly decimal[] ValidAmounts = {
        0.01M,
        49_999.51M,
        99_999
    };
    
    /// <summary>
    /// With valid values, throws nothing.
    /// </summary>
    /// <param name="rawSurface">Represents the raw value of <see cref="Surface" />.</param>
    [Test]
    public void With_Valid_Values_Throws_Nothing([ValueSource(nameof(ValidAmounts))] decimal rawSurface)
        => Assert.That(() => Surface.From(rawSurface), Throws.Nothing);

    /// <summary>
    /// With below minimum throws <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="rawSurface">Represents the raw value of <see cref="Surface" />.</param>
    [TestCase(-0.01)]
    [TestCase(0)]
    public void With_Below_Minimum_Throws_ArgumentOutOfRangeException(decimal rawSurface)
        => Assert.That(() => Surface.From(rawSurface), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    /// With above maximum throws <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="rawSurface"></param>
    [TestCase(99_999.01)]
    [TestCase(100_000)]
    public void With_Above_Maximum_Throws_ArgumentOutOfRangeException(decimal rawSurface)
        => Assert.That(() => Surface.From(rawSurface), Throws.InstanceOf<ArgumentOutOfRangeException>());
}