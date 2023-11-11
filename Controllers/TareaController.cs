using Microsoft.AspNetCore.Mvc;
using Kanban.Repository;
using Kanban.Models;

namespace Kanban.Controllers;

[ApiController]
[Route("[controller]")]

public class TareaController : ControllerBase
{
    private ITareaRepository tareaRepository;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }
    
    [HttpPost("CrearTarea")]
    public ActionResult<Tarea> CreateTarea(int idTablero, Tarea tareaNueva)
    {
        tareaRepository.CreateTarea(idTablero, tareaNueva);
        return Ok(tareaNueva);
    }

    [HttpPut("ModificarTarea")]
    public ActionResult<Tarea> UpdateTarea(int idTarea, Tarea tareaModificada)
    {
        tareaRepository.UpdateTarea(idTarea, tareaModificada);
        return Ok(tareaModificada);
    }

    [HttpPut("ModificarEstadoTarea")]
    public ActionResult UpdateEstadoTarea(int idTarea, EstadoTarea estado)
    {
        Tarea tarea = tareaRepository.GetTareaById(idTarea);
        tarea.Estado = estado;

        tareaRepository.UpdateTarea(idTarea, tarea);
        return Ok();
    }

    [HttpDelete("EliminarTarea")]
    public ActionResult<Tarea> DeleteTarea(int idTarea)
    {
        tareaRepository.DeleteTarea(idTarea);
        return Ok();
    }

    [HttpGet("CantidadTareasPorEstado")]
    public ActionResult<List<Tarea>> CantidadTareasPorEstado(EstadoTarea estado)
    {
        List<Tarea> tareas = tareaRepository.GetAllTareas().FindAll(t => t.Estado == estado);

        if(tareas != null)
        {
            return Ok(tareas);
        } else
        {
            return NotFound();
        }
    }

    [HttpGet("GetTareasByUsuario")]
    public ActionResult<List<Tarea>> GetTareasByUsuario(int idUsuario)
    {
        List<Tarea> tareas = tareaRepository.GetAllTareasByUsuario(idUsuario);
        
        if(tareas != null)
        {
            return Ok(tareas);
        } else
        {
            return NotFound();
        }
    }

    [HttpGet("GetTareasByTablero")]
    public ActionResult<List<Tarea>> GetTareasByTablero(int idTablero)
    {
        List<Tarea> tareas = tareaRepository.GetAllTareasByTablero(idTablero);
        
        if(tareas != null)
        {
            return Ok(tareas);
        } else
        {
            return NotFound();
        }
    }
}
