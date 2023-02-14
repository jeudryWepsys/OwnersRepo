using Microsoft.AspNetCore.Mvc;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;
using WebApiExample.ViewModels;

namespace WebApiExample.Controllers;

/// <summary>
/// Represents an owner's controller which manage all stuff about owners.
/// </summary>
[Route("api/owners")]
[ApiController]
public sealed class ImmovablesController: ControllerBase
{
    private readonly IOwnerRepository _ownerRepository;
    private IPropertyRepositoryDummy _propertyRepositoryDummy;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImmovablesController"/> class.
    /// </summary>
    /// <param name="ownerRepository">Can not be <see langword="null"/>.</param>
    /// <param name="propertyRepositoryDummy"></param>
    public ImmovablesController(IOwnerRepository ownerRepository, IPropertyRepositoryDummy propertyRepositoryDummy)
    {
        _ownerRepository = ownerRepository;
        _propertyRepositoryDummy = propertyRepositoryDummy;
    }
    
    /// <summary>
    /// Gets all owners.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Retrieve()
    {
        return Ok(_ownerRepository.Retrieve().Select(OwnerModel.FromEntity));
    }
    
    /// <summary>
    /// Persists an owner with its properties.
    /// </summary>
    /// <param name="ownerModel">Represents the owner's model.</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult SaveOwner([FromBody] OwnerModel ownerModel)
    {
        Owner owner = ownerModel.ToEntity();

        owner.Persists(_ownerRepository);
        return Ok(OwnerModel.FromEntity(owner));
    }
    
    /// <summary>
    /// Delete all properties.
    /// </summary>
    /// <param name="propertyId">Represents the property id.</param>
    /// <returns></returns>
    [HttpDelete ("{ownerId}/properties/{propertyId}")]
    public IActionResult DeletePropertyFromOwner(Guid ownerId, Guid propertyId)
    {
        Owner owner = _ownerRepository.GetOwnerById(ownerId);
        owner.Delete(_propertyRepositoryDummy, propertyId);
        return Ok();
    }
    
    /// <summary>
    /// Updates owner's property.
    /// </summary>
    /// <param name="propertyId">Represents the property id.</param>
    /// <param name="propertyViewModel">Represents the property view model.</param>
    /// <returns></returns>
    [HttpPut ("{ownerId}/properties/{propertyId}")]
    public IActionResult UpdatePropertyFromOwner(Guid ownerId, Guid propertyId, [FromBody] PropertyModel propertyViewModel)
    {
        Property propertyToUpdate = propertyViewModel.ToEntity();
        Owner owner = _ownerRepository.GetOwnerById(ownerId);
        owner.Update(_propertyRepositoryDummy, propertyId, propertyToUpdate);
        return Ok(PropertyModel.FromEntity(propertyToUpdate));
    }
}