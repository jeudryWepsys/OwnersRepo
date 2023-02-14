using RI.Novus.Core.Inmovable.Owners;
using Triplex.ProtoDomainPrimitives.Numerics;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerCodiaFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    /// <summary>
    /// With a future date throws <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="rawCode">Represents the raw code.</param>
    [Test]
    public void With_Values_Outside_Range_Throws_ArgumentOutOfRangeException([Values(0, -1)] int rawCode)
        => Assert.That(() => new Codia(new PositiveInteger(rawCode)), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    /// With a future date throws <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="rawCode"> Represents the raw code. </param>
    [Test]
    public void With_Values_Inside_Range_Throws_Nothing([Random(1, 10, 100)] int rawCode)
        => Assert.That(() => new Codia(new PositiveInteger(rawCode)), Throws.Nothing);
}
