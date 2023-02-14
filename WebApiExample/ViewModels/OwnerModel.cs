using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;
using Triplex.Validations;

namespace WebApiExample.ViewModels;

/// <summary>
/// Represents an owner's model.
/// </summary>
public sealed class OwnerModel
{
    /// <summary>
    /// Indicates owner's id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Indicates owner's name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Indicates owner's identification number.
    /// </summary>
    public string IdentificationNumber { get; set; }
    
    /// <summary>
    /// Indicates owner's createdDate.
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }
    
    /// <summary>
    /// Indicates owner's codia.
    /// </summary>
    public int Codia { get; set; }
    
    /// <summary>
    /// Indicates owner's properties.
    /// </summary>
    public IEnumerable<PropertyModel> Properties { get; set; }

    /// <summary>
    /// Converts to Owner entity.
    /// </summary>
    /// <returns>An instance of <see cref="RI.Novus.Core.Asegurados.Asegurado"/></returns>
    public Owner ToEntity()
    {
        Guid ownerId = Guid.NewGuid();
        
        IEnumerable<Property> propertie = Properties.Select(x => new Property.Builder() 
            .WithSurface(Surface.From(Properties.Select(x => x.Surface).FirstOrDefault()))
            .WithType(Properties.Select(x => x.Type).FirstOrDefault())
            .WithArea(Area.From(Properties.Select(x => x.Area).FirstOrDefault() ?? 0)) 
            .WithRegion(Region.From(Properties.Select(x => x.Region).FirstOrDefault() ?? 0))
            .WithOwnerId(ownerId)
            .Build());

        return new Owner.Builder()
            .WithId(RI.Novus.Core.Inmovable.Owners.Id.From(ownerId))
            .WithName(RI.Novus.Core.Inmovable.Owners.Name.From(Name))
            .WithIdentificationNumber(RI.Novus.Core.Inmovable.Owners.IdentificationNumber.From(IdentificationNumber))
            .WithCreatedDate(RI.Novus.Core.Inmovable.Owners.CreatedDate.Now())
            .WithCodia(RI.Novus.Core.Inmovable.Owners.Codia.From(Codia))
            .WithProperties(propertie)
            .Build();
    } 
    
    /// <summary>
    /// Converts from Owner entity.
    /// </summary>
    /// <param name="owner">Represents an owner.</param>
    /// <returns></returns>
    public static OwnerModel FromEntity(Owner owner)
    {
        Arguments.NotNull(owner, nameof(owner));

        return new OwnerModel
        {
            Id = owner.Id.Value,
            Name = owner.Name.Value,
            IdentificationNumber = owner.IdentificationNumber.Value,
            CreatedDate = owner.CreatedDate.AsPrimitive,
            Codia = owner.Codia.AsPrimitive,
            Properties = owner.Properties.Select(PropertyModel.FromEntity).ToList()
        };
    }
}