using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerIdentificationNumber;

[TestFixture]
internal sealed class ConstructorFacts
{
    private static readonly string[] ValidOwnerIdentificationNumber = {
            "40213479477",
            "40213479476",
            "40213479478"
        };

    /// <summary>
    /// <see cref="IdentificationNumber" /> with <c>null</c> throws <see cref="ArgumentNullException" />.
    /// </summary>
    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => new IdentificationNumber(null!), Throws.ArgumentNullException);

    /// <summary>
    /// <see cref="IdentificationNumber" /> with empty and less than minimum whitespaces throws <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="rawIdentificationNumber">Represents the raw value of <see cref="IdentificationNumber" />.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_And_Less_Than_Minimum_Whitespaces_Throws_ArgumentOutOfRangeException(string rawIdentificationNumber)
        => Assert.That(() => new IdentificationNumber(rawIdentificationNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    /// <see cref="IdentificationNumber" /> with leading and trailing whitespaces throws <see cref="FormatException" />.
    /// </summary>
    /// <param name="rawIdentificationNumber"></param>
    [TestCase(" 4021347 7")]
    [TestCase("4021347 7 ")]
    [TestCase(" 4021347 7 ")]
    public void With_Leading_And_Trailing_Whitespaces_Throws_FormatException(string rawIdentificationNumber)
        => Assert.That(() => new IdentificationNumber(rawIdentificationNumber), Throws.InstanceOf<FormatException>());

    /// <summary>
    /// <see cref="IdentificationNumber" /> with invalid pattern throws <see cref="FormatException" />.
    /// </summary>
    /// <param name="rawIdentificationNumber"></param>
    [TestCase("4021")]
    [TestCase("40214")]
    public void With_Shorter_Than_Minimum_Throws_ArgumentOutOfRangeException(string rawIdentificationNumber)
        => Assert.That(() => new IdentificationNumber(rawIdentificationNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    /// <see cref="IdentificationNumber" /> with invalid pattern throws <see cref="FormatException" />.
    /// </summary>
    /// <param name="rawIdentificationNumber"></param>
    [TestCase("40213479474512321")]
    public void With_Larger_Than_Maximum_Throws_ArgumentOutOfRangeException(string rawIdentificationNumber)
    {
        Assert.That(() => new IdentificationNumber(rawIdentificationNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
    
    /// <summary>
    /// <see cref="IdentificationNumber" /> with invalid pattern throws <see cref="FormatException" />.
    /// </summary>
    /// <param name="rawIdentificationNumber"></param>
    [Test]
    public void With_Valid_Pattern_Throws_Nothing([ValueSource(nameof(ValidOwnerIdentificationNumber))] string rawIdentificationNumber)
        => Assert.That(() => new IdentificationNumber(rawIdentificationNumber), Throws.Nothing);
}