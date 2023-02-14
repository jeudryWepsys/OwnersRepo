using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoNameFacts;

internal sealed class EqualsMessageFacts : AbstractEquatableTestFixture<Name>
{
    protected override Context BuildContext()
    {
        const string rawAseguradoName = "Asegurado1";
        Name subject = new(rawAseguradoName);

        return new Context(
            subject: subject,
            subjectCopy: new Name(rawAseguradoName),
            other: new Name("Asegurado2"),
            otherSemanticallyEqualsToSubject: new Name("Asegurado1"));
    }
}