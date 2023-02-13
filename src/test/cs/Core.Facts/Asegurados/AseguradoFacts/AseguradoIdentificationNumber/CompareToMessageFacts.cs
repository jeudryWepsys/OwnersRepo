using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.AseguradoIdentificationNumber;

internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<IdentificationNumber>
{
    protected override Context BuildContext()
    {
        const string rawAseguradoIdentificationNumber = "40213479477";
        IdentificationNumber subject = new(rawAseguradoIdentificationNumber);

        return new Context(
            lessThanSubject: new IdentificationNumber("4021347947"),
            subject: subject,
            subjectCopy: new IdentificationNumber(rawAseguradoIdentificationNumber),
            otherSemanticallyEqualsToSubject: new IdentificationNumber("40213479477"),
            greatherThanSubject: new IdentificationNumber("40213479478"),
            testRelationalOperatorsOverload: true);
    }

    protected override bool ExecuteEqualsOperator(IdentificationNumber left, IdentificationNumber right)
        => left == right;
    protected override bool ExecuteNotEqualsOperator(IdentificationNumber left, IdentificationNumber right)
        => left != right;
    protected override bool ExecuteLessThanOperator(IdentificationNumber left, IdentificationNumber right)
        => left < right;
    protected override bool ExecuteLessThanOrEqualsToOperator(IdentificationNumber left, IdentificationNumber right)
        => left <= right;
    protected override bool ExecuteGreaterThanOperator(IdentificationNumber left, IdentificationNumber right)
        => left > right;
    protected override bool ExecuteGreaterThanOrEqualsToOperator(IdentificationNumber left, IdentificationNumber right)
        => left >= right;
}
