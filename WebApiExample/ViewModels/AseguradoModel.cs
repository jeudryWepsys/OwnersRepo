using RI.Novus.Core.Asegurados;
using Triplex.Validations;

namespace WebApiExample.ViewModels;

/// <summary>
/// Represents an asegurado's model.
/// </summary>
public sealed class AseguradoModel
{
    /// <summary>
    /// Indicates asegurado's id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Indicates asegurado's name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Indicates asegurado's identification number.
    /// </summary>
    public string IdentificationNumber { get; set; }
    
    /// <summary>
    /// Indicates asegurado's birthdate.
    /// </summary>
    public DateTimeOffset Birthdate { get; set; }
    
    /// <summary>
    /// Indicates asegurado's age.
    /// </summary>
    public int Age { get; set; }
    
    /// <summary>
    /// Converts to Property entity.
    /// </summary>
    /// <returns>An instance of <see cref="Asegurado"/></returns>
    public Asegurado ToEntity()
    {
        return new Asegurado.Builder()
            .WithName(RI.Novus.Core.Asegurados.Name.From(Name))
            .WithIdentificationNumber(RI.Novus.Core.Asegurados.IdentificationNumber.From(IdentificationNumber))
            .WithBirthdate(RI.Novus.Core.Asegurados.Birthday.From(Birthdate))
            .WithAge(RI.Novus.Core.Asegurados.Age.From(Age))
            .Build();   
    } 
    
    /// <summary>
    /// Converts from Property entity.
    /// </summary>
    /// <param name="asegurado">Represents an asegurado.</param>
    /// <returns></returns>
    public static AseguradoModel FromEntity(Asegurado asegurado)
    {
        Arguments.NotNull(asegurado, nameof(asegurado));

        return new AseguradoModel
        {
            Id = asegurado.Id.Value,
            Name = asegurado.Name.Value,
            IdentificationNumber = asegurado.IdentificationNumber.Value,
            Birthdate = asegurado.Birthday.AsPrimitive,
            Age = asegurado.Age.AsPrimitive
        };
    }
}