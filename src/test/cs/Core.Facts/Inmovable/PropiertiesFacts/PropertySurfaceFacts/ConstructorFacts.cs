using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;
using Triplex.ProtoDomainPrimitives.Numerics;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.PropertySurfaceFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    /// <summary>
    /// Tests that the <see cref="Name"/> constructor throws an <see cref="ArgumentNullException"/>
    /// </summary>
    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => new Surface(new decimal(null)), Throws.InstanceOf<ArgumentNullException>());
    
    /// <summary>
    /// With a future date throws <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="rawCode">Represents the raw code.</param>
    [Test]
    public void With_Values_Outside_Range_Throws_ArgumentOutOfRangeException([Values(0, -1)] int rawCode)
        => Assert.That(() => new Surface(rawCode), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    /// With a future date throws <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="rawCode"> Represents the raw code. </param>
    [Test]
    public void With_Values_Inside_Range_Throws_Nothing([Random(1, 10, 100)] int rawCode)
        => Assert.That(() => new Surface(rawCode), Throws.Nothing);
}