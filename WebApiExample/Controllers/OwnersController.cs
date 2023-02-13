using Microsoft.AspNetCore.Mvc;
using RI.Novus.Core.Asegurados;
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
public sealed class OwnersController: ControllerBase
{
    private readonly IOwnerRepositoryDummy _ownerRepositoryDummy;    
    
    /// <summary>
    /// Initializes a new instance of the <see cref="OwnersController"/> class.
    /// </summary>
    /// <param name="ownerRepositoryDummy">Can not be <see langword="null"/>.</param>
    public OwnersController(IOwnerRepositoryDummy ownerRepositoryDummy)
    {
        _ownerRepositoryDummy = ownerRepositoryDummy;
    }
    
    /// <summary>
    /// Gets all owners.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Retrieve()
    {
        return Ok(_ownerRepositoryDummy.Retrieve().Select(OwnerModel.FromEntity));
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

        owner.Persists(_ownerRepositoryDummy);
        return Ok(OwnerModel.FromEntity(owner));
    }
}