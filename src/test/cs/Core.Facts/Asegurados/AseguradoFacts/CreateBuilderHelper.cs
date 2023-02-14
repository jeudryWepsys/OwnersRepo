using RI.Novus.Core.Asegurados;
using Triplex.ProtoDomainPrimitives.Numerics;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        Name,
        IdentificationNumber,
        Birthdate,
        Age
    }
    internal static Asegurado.Builder CreateUsedBuilder()
    {
        Asegurado.Builder builder = CreateFullBuilder();

        _ = builder.Build();    

        return builder;
    }

    internal static Asegurado.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    
    internal static Asegurado.Builder CreateBuilderWithoutId() 
        => CreateBuilderWithout(BuilderProperty.Id);
    
    internal static Asegurado.Builder CreateBuilderWithoutName()
        => CreateBuilderWithout(BuilderProperty.Name);
    
    internal static Asegurado.Builder CreateBuilderWithoutIdentificationNumber()
        => CreateBuilderWithout(BuilderProperty.IdentificationNumber);
    
    internal static Asegurado.Builder CreateBuilderWithoutBirthdate()
        => CreateBuilderWithout(BuilderProperty.Birthdate);
    
    internal static Asegurado.Builder CreateBuilderWithoutAge()
        => CreateBuilderWithout(BuilderProperty.Age);
    
    internal static Asegurado.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<Asegurado.Builder>> setters
            = new Dictionary<BuilderProperty, Action<Asegurado.Builder>>
        {
            [BuilderProperty.Id] = b 
                => b.WithId(Id.Generate()),
            [BuilderProperty.Name] = b
                => b.WithName(new Name("Asegurado1")),
            [BuilderProperty.IdentificationNumber] = b
                => b.WithIdentificationNumber(new IdentificationNumber("40213479576")),
            [BuilderProperty.Age] = b
                => b.WithAge(new Age(new PositiveInteger(1))),
            [BuilderProperty.Birthdate] = b
                => b.WithBirthdate(new Birthday(new PastOrPresentTimestamp( new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))))
        };

        var builder = new Asegurado.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
