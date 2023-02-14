using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoNameFacts;

[TestFixture]
internal sealed class GetHashCodeMessageFacts : AbstractGetHashCodeTestFixture<Name>
{
    protected override Context BuildContext()
    {
        const string rawName = "Asegurado1";
        Name subject = new(rawName);

        return new Context(
            subject: subject,
            subjectCopy: new Name(rawName),
            other: new Name("Asegurado2"),
            otherSemanticallyEqualsToSubject: new Name("Asegurado1"));
    }
}
