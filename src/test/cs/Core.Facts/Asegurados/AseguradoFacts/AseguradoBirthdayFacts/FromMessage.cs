using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoBirthdayFacts;

[TestFixture]
internal sealed class FromMessage
{
    /// <summary>
    ///  With a future date throws <see cref="ArgumentException" />.
    /// </summary>
    [Test]
    public void With_Past_Date_Throws_Nothing()
        => Assert.That(() => Birthday.From(DateTimeOffset.UtcNow.AddDays(-1)), Throws.Nothing);
}
