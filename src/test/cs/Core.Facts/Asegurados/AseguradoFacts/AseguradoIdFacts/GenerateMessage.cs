using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoIdFacts;

[TestFixture]
internal sealed class GenerateMessage
{
    /// <summary>
    /// All generated Ids are distinct.
    /// </summary>
    /// <param name="count"></param>
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(8)]
    public void All_Are_Distinct(int count)
    {
        ISet<Id> ids = Enumerable.Range(0, count).Select(_ => Id.Generate()).ToHashSet();

        Assert.That(ids, Has.Count.EqualTo(count));
    }
}
