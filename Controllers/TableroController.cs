using Microsoft.AspNetCore.Mvc;
using Kanban.Repository;
using Kanban.Models;

namespace Kanban.Controllers;

[ApiController]
[Route("[controller]")]

public class TableroController : ControllerBase
{
    private ITableroRepository tableroRepository;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    [HttpPost("CrearTablero")]
    public ActionResult<Tablero> CreateTablero(Tablero tableroNuevo)
    {
        tableroRepository.CreateTablero(tableroNuevo);
        return Ok(tableroNuevo);
    }

    [HttpGet("GetAllTableros")]
    public ActionResult<List<Tablero>> GetAllTableros()
    {
        List<Tablero> tableros = tableroRepository.GetAllTableros();
        
        if (tableros != null)
        {
            return Ok(tableros);
        } else
        {
            return NotFound();
        }
    }
}