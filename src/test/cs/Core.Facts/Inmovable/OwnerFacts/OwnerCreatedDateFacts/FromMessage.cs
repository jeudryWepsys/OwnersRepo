using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerCreatedDateFacts;

[TestFixture]
internal sealed class FromMessage
{
    /// <summary>
    ///  With a future date throws <see cref="ArgumentException" />.
    /// </summary>
    [Test]
    public void With_Past_Date_Throws_Nothing()
        => Assert.That(() => CreatedDate.From(DateTimeOffset.UtcNow.AddDays(-1)), Throws.Nothing);
}
