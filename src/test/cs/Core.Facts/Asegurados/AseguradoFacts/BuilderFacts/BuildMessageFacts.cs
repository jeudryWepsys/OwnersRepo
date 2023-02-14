using RI.Novus.Core.Asegurados;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

[TestFixture]
internal sealed class BuildMessageFacts
{
    /// <summary>
    ///   Tests that the <see cref="Asegurado.Builder.Build"/> method throws an <see cref="InvalidOperationException"/> when the <see cref="Asegurado.Builder"/> is missing a required property.
    /// </summary>
    /// <param name="missingProperty"></param>
    [Test]
    public void With_Missing_Required_Property_Throws_InvalidOperationException([Values] BuilderProperty missingProperty)
    {
        Assume.That(missingProperty, Is.Not.EqualTo(BuilderProperty.None)
            .And.Not.EqualTo(BuilderProperty.Id));

        Asegurado.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.InvalidOperationException);
    }

    /// <summary>
    ///  Tests that the <see cref="Asegurado.Builder.Build"/> method throws an <see cref="InvalidOperationException"/> when the <see cref="Asegurado.Builder"/> is missing a required property.
    /// </summary>
    /// <param name="missingProperty"></param>
    [Test]
    public void With_All_Required_Throws_Nothing([Values(BuilderProperty.None)] BuilderProperty missingProperty)
    {
        Asegurado.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.Nothing);
    }
}
