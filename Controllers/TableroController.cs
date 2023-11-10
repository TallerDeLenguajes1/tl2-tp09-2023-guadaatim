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

    [HttpPost]
    public ActionResult CreateTablero(Tablero tableroNuevo)
    {
        tableroRepository.CreateTablero(tableroNuevo);
        return Ok(tableroNuevo);
    }

    [HttpGet]
    public ActionResult GetAllTableros()
    {
        List<Tablero> tableros = tableroRepository.GetAllTablero();
        
        if (tableros != null)
        {
            return Ok(tableros);
        } else
        {
            return NotFound();
        }
    }
}