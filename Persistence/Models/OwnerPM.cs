using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RI.Novus.Core.Inmovable.Owners;
using Triplex.Validations;

namespace Persistence.Models;

/// <summary>
/// Represents the database representation for an owner.
/// </summary>
public sealed class OwnerPM
{
    /// <summary>
    /// Creates a instance of <see cref="OwnerPM"/>
    /// </summary>
    /// <param name="id">Represents the owner db id.</param>
    /// <param name="name">Represents the owner db name.</param>
    /// <param name="identificationNumber">Represents the owner db identification number.</param>
    /// <param name="createdDate">Represents the owner db created date.</param>
    /// <param name="codia">Represents the owner db codia.</param>
    public OwnerPM(Guid id, string name, string identificationNumber, DateTimeOffset createdDate, int codia) 
    {
        Id = id;
        Name = name;
        IdentificationNumber = identificationNumber;
        CreatedDate = createdDate;
        Codia = codia;
    }
    
    /// <summary>
    /// Indicates owner db id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Indicates owner db name.
    /// </summary>
    [MinLength(RI.Novus.Core.Inmovable.Owners.Name.MinLength),
     MaxLength(RI.Novus.Core.Inmovable.Owners.Name.MaxLength)]
    [Required]
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Indicates owner db identification number.
    /// </summary>
    [MinLength(RI.Novus.Core.Inmovable.Owners.IdentificationNumber.MinLength),
     MaxLength(RI.Novus.Core.Inmovable.Owners.IdentificationNumber.MaxLength)]
    [Required]
    public string IdentificationNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Indicates owner db created date.
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    
    /// <summary>
    /// Indicates owner db codia.
    /// </summary>
    [Required]
    [Range(1, int.MaxValue)]
    public int Codia { get; set; }

    /// <summary>
    /// Indicates owner db properties.
    /// </summary>
    [NotMapped] 
    public IList<PropertyPM> Properties { get; set; } 
    
    /// <summary>
    /// Converts a model to an entity.
    /// </summary>
    /// <returns></returns>
    public Owner ToEntity()
    {
        return new Owner.Builder()
            .WithId(RI.Novus.Core.Inmovable.Owners.Id.From(Id))
            .WithName(RI.Novus.Core.Inmovable.Owners.Name.From(Name))
            .WithIdentificationNumber(RI.Novus.Core.Inmovable.Owners.IdentificationNumber.From(IdentificationNumber))
            .WithCreatedDate(RI.Novus.Core.Inmovable.Owners.CreatedDate.From(CreatedDate))
            .WithCodia(RI.Novus.Core.Inmovable.Owners.Codia.From(Codia))
            .WithProperties(Properties.Select(i => i.ToEntity()).ToList())
            .Build();
    }
    
    /// <summary>
    /// Converts an entity to a model.
    /// </summary> 
    /// <param name="owner">The owner entity.</param>
    /// <returns></returns>
    public static OwnerPM FromEntity(Owner owner)
    {
        Arguments.NotNull(owner, nameof(owner));

        return new (owner.Id.Value, owner.Name.Value, owner.IdentificationNumber.Value, owner.CreatedDate.AsPrimitive, owner.Codia.AsPrimitive);
    }
}