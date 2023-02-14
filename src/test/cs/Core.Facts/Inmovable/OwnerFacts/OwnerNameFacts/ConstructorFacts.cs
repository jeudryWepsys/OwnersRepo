using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerNameFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    private static readonly string[] ValidOwnerName = {
            "Owner1",
            "Owner2",
            "Owner3"
        };

    /// <summary>
    /// Tests that the <see cref="Name"/> constructor throws an <see cref="ArgumentNullException"/>
    /// </summary>
    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => new Name(null!), Throws.ArgumentNullException);

    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="ArgumentOutOfRangeException"/>
    /// </summary>
    /// <param name="rawOwnerName"> Represents the raw asegurado name </param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_And_Less_Than_Minimum_Whitespaces_Throws_ArgumentOutOfRangeException(string rawOwnerName)
        => Assert.That(() => new Name(rawOwnerName), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="FormatException"/>
    /// </summary>
    /// <param name="rawOwnerName"></param>
    [TestCase(" Asegurado 1")]
    [TestCase("Asegurado 1 ")]
    [TestCase(" Asegurado 1 ")]
    public void With_Leading_And_Trailing_Whitespaces_Throws_FormatException(string rawOwnerName)
        => Assert.That(() => new Name(rawOwnerName), Throws.InstanceOf<FormatException>());

    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="ArgumentOutOfRangeException"/>
    /// </summary>
    /// <param name="rawOwnerName"></param>
    [TestCase("Pe")]
    [TestCase("P")]
    public void With_Shorter_Than_Minimum_Throws_ArgumentOutOfRangeException(string rawOwnerName)
        => Assert.That(() => new Name(rawOwnerName), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="ArgumentOutOfRangeException"/>
    /// </summary>
    /// <param name="rawOwnerName"></param>
    [TestCase("PedroPedroPedroPedroPedro")]
    public void With_Larger_Than_Maximum_Throws_ArgumentOutOfRangeException(string rawOwnerName)
    {
        Assert.That(() => new Name(rawOwnerName), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
    
    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="FormatException"/>
    /// </summary>
    /// <param name="rawDesignation"></param>
    [Test]
    public void With_Valid_Pattern_Throws_Nothing([ValueSource(nameof(ValidOwnerName))] string rawDesignation)
        => Assert.That(() => new Name(rawDesignation), Throws.Nothing);
}