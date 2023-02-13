using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoNameFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    private static readonly string[] ValidAseguradoName = {
            "Asegurado1",
            "Asegurado2",
            "Asegurado3"
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
    /// <param name="rawAseguradoName"></param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_And_Less_Than_Minimum_Whitespaces_Throws_ArgumentOutOfRangeException(string rawAseguradoName)
        => Assert.That(() => new Name(rawAseguradoName), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="FormatException"/>
    /// </summary>
    /// <param name="rawAseguradoName"></param>
    [TestCase(" Property 1")]
    [TestCase("Property 1 ")]
    [TestCase(" Property 1 ")]
    public void With_Leading_And_Trailing_Whitespaces_Throws_FormatException(string rawAseguradoName)
        => Assert.That(() => new Name(rawAseguradoName), Throws.InstanceOf<FormatException>());

    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="ArgumentOutOfRangeException"/>
    /// </summary>
    /// <param name="rawAseguradoName"></param>
    [TestCase("Pe")]
    [TestCase("P")]
    public void With_Shorter_Than_Minimum_Throws_ArgumentOutOfRangeException(string rawAseguradoName)
        => Assert.That(() => new Name(rawAseguradoName), Throws.InstanceOf<ArgumentOutOfRangeException>());

    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="ArgumentOutOfRangeException"/>
    /// </summary>
    /// <param name="rawAseguradoName"></param>
    [TestCase("PedroPedroPedroPedroPedro")]
    public void With_Larger_Than_Maximum_Throws_ArgumentOutOfRangeException(string rawAseguradoName)
    {
        Assert.That(() => new Name(rawAseguradoName), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
    
    /// <summary>
    ///  Tests that the <see cref="Name"/> constructor throws an <see cref="FormatException"/>
    /// </summary>
    /// <param name="rawDesignation"></param>
    [Test]
    public void With_Valid_Pattern_Throws_Nothing([ValueSource(nameof(ValidAseguradoName))] string rawDesignation)
        => Assert.That(() => new Name(rawDesignation), Throws.Nothing);
}