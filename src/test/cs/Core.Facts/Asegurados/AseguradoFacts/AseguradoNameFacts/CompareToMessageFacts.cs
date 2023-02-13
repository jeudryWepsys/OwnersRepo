using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoNameFacts;

internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<Name>
{
    protected override Context BuildContext()
    {
        const string rawAseguradoName = "Asegurado1";
        Name subject = new(rawAseguradoName);

        return new Context(
            lessThanSubject: new Name("Asegurado"),
            subject: subject,
            subjectCopy: new Name(rawAseguradoName),
            otherSemanticallyEqualsToSubject: new Name("Asegurado1"),
            greatherThanSubject: new Name("Asegurado2"),
            testRelationalOperatorsOverload: true);
    }

    protected override bool ExecuteEqualsOperator(Name left, Name right)
        => left == right;
    protected override bool ExecuteNotEqualsOperator(Name left, Name right)
        => left != right;
    protected override bool ExecuteLessThanOperator(Name left, Name right)
        => left < right;
    protected override bool ExecuteLessThanOrEqualsToOperator(Name left, Name right)
        => left <= right;
    protected override bool ExecuteGreaterThanOperator(Name left, Name right)
        => left > right;
    protected override bool ExecuteGreaterThanOrEqualsToOperator(Name left, Name right)
        => left >= right;
}
