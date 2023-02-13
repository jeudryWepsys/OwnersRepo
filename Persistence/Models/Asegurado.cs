using RI.Novus.Core.Asegurados;
using Triplex.Validations;

namespace Persistence.Models;

/// <summary>
/// Represents the database representation for an asegurado.
/// </summary>
public sealed class Asegurado
{
    /// <summary>
    /// Creates a instance of <see cref="Asegurado"/>
    /// </summary>
    /// <param name="id">Represents the asegurado id.</param>
    /// <param name="name">Represents the asegurado name.</param>
    /// <param name="identificationNumber">Represents the asegurado identification number.</param>
    /// <param name="birthdate">Represents the asegurado birthdate.</param>
    /// <param name="age">Represents the asegurado age.</param>
    public Asegurado(Guid id, string name, string identificationNumber, DateTimeOffset birthdate, int age)
    {
        Id = id;
        Name = name;
        IdentificationNumber = identificationNumber;
        Birthdate = birthdate;
        Age = age;
    }
    
    /// <summary>
    /// Indicates asegurado id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Indicates asegurado name.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Indicates asegurado identification number.
    /// </summary>
    public string IdentificationNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Indicates asegurado birthdate.
    /// </summary>
    public DateTimeOffset Birthdate { get; set; } = DateTimeOffset.Now;
    
    /// <summary>
    /// Indicates asegurado age.
    /// </summary>
    public int Age { get; set; } 

    /// <summary>
    /// Converts current model to Property entity.
    /// </summary>
    /// <returns>An instance of <see cref="RI.Novus.Core.Asegurados.Asegurado"/></returns>
    public RI.Novus.Core.Asegurados.Asegurado ToEntity()
    {
        return new RI.Novus.Core.Asegurados.Asegurado.Builder()
            .WithId(RI.Novus.Core.Asegurados.Id.From(Id))
            .WithName(RI.Novus.Core.Asegurados.Name.From(Name))
            .WithIdentificationNumber(RI.Novus.Core.Asegurados.IdentificationNumber.From(IdentificationNumber))
            .WithBirthdate(RI.Novus.Core.Asegurados.Birthday.From(Birthdate))
            .WithAge(RI.Novus.Core.Asegurados.Age.From(Age))
            .Build();
    }
    
    /// <summary>
    /// Converts an entity to a model.
    /// </summary> 
    /// <param name="asegurado">The asegurado entity.</param>
    /// <returns></returns>
    public static Asegurado FromEntity(RI.Novus.Core.Asegurados.Asegurado asegurado)
    {
        Arguments.NotNull(asegurado, nameof(asegurado));

        return new Asegurado(asegurado.Id.Value, asegurado.Name.Value, asegurado.IdentificationNumber.Value, asegurado.Birthday.AsPrimitive, asegurado.Age.AsPrimitive);
    }
}