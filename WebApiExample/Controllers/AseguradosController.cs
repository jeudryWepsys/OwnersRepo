using Microsoft.AspNetCore.Mvc;
using RI.Novus.Core.Asegurados;
using RI.Novus.Core.Boundaries.Persistence;
using WebApiExample.ViewModels;

namespace WebApiExample.Controllers;

/// <summary>
/// Represents an asegurado's controller which manage all stuff about asegurados.
/// </summary>
[Route("api/asegurados")]
[ApiController]
public sealed class AseguradosController: ControllerBase
{
    private readonly IAseguradosRepositoryDummy _aseguradoRepositoryDummy;    
    
    /// <summary>
    /// Creates a new instance of <see cref="AseguradosController"/>.
    /// </summary>
    /// <param name="aseguradoRepositoryDummy">Can not be <see langword="null"/>.</param>
    public AseguradosController(IAseguradosRepositoryDummy aseguradoRepositoryDummy)
    {
        _aseguradoRepositoryDummy = aseguradoRepositoryDummy;
    }

    /// <summary>
    /// Gets an asegurado by its id.
    /// </summary>
    /// <param name="id">Represents the asegurado's id.</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        Asegurado asegurado = _aseguradoRepositoryDummy.GetAseguradoById(id);
        return Ok(AseguradoModel.FromEntity(asegurado));
    }
    
    /// <summary>
    /// Gets all asegurados.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Retrieve()
    {
        return Ok(_aseguradoRepositoryDummy.Retrieve().Select(AseguradoModel.FromEntity));
    }
    
    /// <summary>
    /// Persists an asegurado.
    /// </summary>
    /// <param name="aseguradoModel">Represents the asegurado's model.</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult SaveAsegurado([FromBody] AseguradoModel aseguradoModel)
    {
        Asegurado asegurado = aseguradoModel.ToEntity();

        asegurado.Persists(_aseguradoRepositoryDummy);
        return Ok(AseguradoModel.FromEntity(asegurado));
    }
    
    /// <summary>
    /// Updates an asegurado.
    /// </summary>
    /// <param name="aseguradoModel">Represents the asegurado's model.</param>
    /// <returns></returns>
    [HttpPatch]
    public IActionResult UpdateAsegurado([FromBody] AseguradoModel aseguradoModel)
    {
        Asegurado asegurado = aseguradoModel.ToEntity();

        asegurado.Update(_aseguradoRepositoryDummy);
        return Ok();
    }
}