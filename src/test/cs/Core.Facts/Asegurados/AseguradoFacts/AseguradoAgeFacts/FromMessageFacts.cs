using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoAgeFacts;

[TestFixture]
internal sealed class FromMessageFacts
{
    /// <summary>
    /// With a non positive integer throws <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="valueAsInt"> Represents the value as int. </param>
    [TestCase(-1)]
    [TestCase(0)]
    public void With_Non_Positive_Integer_Throws_ArgumentOutOfRangeException(int valueAsInt)
        => Assert.That(() => Age.From(valueAsInt), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    /// With a positive integer throws nothing.
    /// </summary>
    /// <param name="valueAsInt">represents the value as int. </param>
    [TestCase(1)]
    [TestCase(10)]
    public void With_Positive_Integer_Throws_Nothing(int valueAsInt)
        => Assert.That(() => Age.From(valueAsInt), Throws.Nothing);

    /// <summary>
    /// With a future date throws <see cref="ArgumentException" />.
    /// </summary>
    [Test]
    public void AsPrimitive_Returns_Same_Value_Provided()
    {
        const int versionAsInt = 1_024;
        var age = Age.From(versionAsInt);

        Assert.That(age.AsPrimitive, Is.EqualTo(versionAsInt));
    }
}
