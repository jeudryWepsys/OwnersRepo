using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using RI.Novus.Core.Asegurados;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Properties;
using WebApiExample.ViewModels;

namespace WebApiExample.Controllers;

/// <summary>
/// Controller for properties.
/// </summary>
[Route("api/properties")]
[ApiController]
public sealed class PropertiesController: ControllerBase
{
    private readonly IPropertyRepositoryDummy _propertyRepositoryDummy;  
    
    /// <summary>
    /// Creates a new instance of <see cref="PropertiesController"/>.
    /// </summary>
    /// <param name="propertyRepositoryDummy">Can not be <see langword="null"/>.</param>
    public PropertiesController(IPropertyRepositoryDummy propertyRepositoryDummy)
    {
        _propertyRepositoryDummy = propertyRepositoryDummy;
    }
    
    /// <summary>
    /// Delete all properties.
    /// </summary>
    /// <param name="propertyId">Represents the property id.</param>
    /// <returns></returns>
    [HttpDelete ("{propertyId}")]
    public IActionResult DeletePropertyFromOwner(Guid propertyId)
    {
        Property.Delete(_propertyRepositoryDummy, propertyId);
        return Ok();
    }
    
    /// <summary>
    /// Updates owner's property.
    /// </summary>
    /// <param name="propertyId">Represents the property id.</param>
    /// <param name="propertyViewModel">Represents the property view model.</param>
    /// <returns></returns>
    [HttpPut ("{propertyId}")]
    public IActionResult UpdatePropertyFromOwner(Guid propertyId, [FromBody] PropertyModel propertyViewModel)
    {
        var propertyToUpdate = propertyViewModel.ToEntity();
        propertyToUpdate.Update(_propertyRepositoryDummy, propertyId);
        return Ok(PropertyModel.FromEntity(propertyToUpdate));
    }
    
}