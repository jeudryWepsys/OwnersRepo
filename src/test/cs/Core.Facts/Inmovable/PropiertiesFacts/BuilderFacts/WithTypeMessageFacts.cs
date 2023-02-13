using System;
using RI.Novus.Core.Inmovable.Properties;
using static RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.CreateBuilderHelper;
using Type = RI.Novus.Core.Inmovable.Properties.Type;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.BuilderFacts;

[TestFixture]
internal sealed class WithTypeMessageFacts
{
    [Test]
    public void With_Valid_Enum_Value_Should_Throw_Nothing([Values] Type type)
    {
        var builder = CreateBuilderWithoutType();

        builder.WithType(type);

        var restService = builder.Build();
        Assert.That(restService.Type, Is.EqualTo(type));
    }

    [TestCase(5)]
    [TestCase(7)]
    [TestCase(8)]
    public void With_Valid_Enum_Value_Should_Throw_Exception(Type type)
    {
        var builder = CreateBuilderWithoutType();

        Assert.That(() => builder.WithType(type), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
}
