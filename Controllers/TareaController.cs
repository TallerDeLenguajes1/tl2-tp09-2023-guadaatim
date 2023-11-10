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
    
    [HttpPost]
    public ActionResult<Tarea> CreateTarea(int idTablero, Tarea tareaNueva)
    {
        tareaRepository.CreateTarea(idTablero, tareaNueva);
        return Ok(tareaNueva);
    }

    [HttpPut]
    public ActionResult<Tarea> UpdateTarea(int idTarea, Tarea tareaModificada)
    {
        tareaRepository.UpdateTarea(idTarea, tareaModificada);
        return Ok(tareaModificada);
    }
/*
    [HttpPut]
    public ActionResult UpdateEstadoTarea(int idTarea, EstadoTarea estado)
    {
        //completar
    }
*/
    [HttpDelete]
    public ActionResult<Tarea> DeleteTarea(int idTarea)
    {
        tareaRepository.DeleteTarea(idTarea);
        return Ok();
    }
/*
    [HttpGet]
    public ActionResult<List<Tarea>> CantidadTareasPorEstado(EstadoTarea estado)
    {
        //completar
    }
*/
    [HttpGet]
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

    [HttpGet]
    public ActionResult<List<Tarea>> GetTareasByTablero(int idTablero)
    {
        List<Tarea> tareas = tareaRepository.GetAllTareaByTablero(idTablero);
        
        if(tareas != null)
        {
            return Ok(tareas);
        } else
        {
            return NotFound();
        }
    }
}
