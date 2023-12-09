using Microsoft.AspNetCore.Mvc;
using Kanban.Repository;
using Kanban.Models;

namespace Kanban.Controllers;

public class UsuarioController : ControllerBase
{
    private IUsuarioRepository usuarioRepository;
    private ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("CrearUsuario")]
    public ActionResult<Usuario> CreateUsuario(Usuario usuarioNuevo)
    {
        usuarioRepository.CreateUsuario(usuarioNuevo);
        return Ok(usuarioNuevo);
    }

    [HttpGet("GetAllUsuarios")]
    public ActionResult<List<Usuario>> GetAllUsuarios()
    {
        List<Usuario> usuarios = usuarioRepository.GetAllUsuarios();

        if(usuarios != null)
        {
            return Ok(usuarios);
        } else
        {
            return NotFound();
        }
    }

    [HttpGet("GetUsuarioById")]
    public ActionResult<Usuario> GetUsuarioById(int idUsuario)
    {
        Usuario usuario = usuarioRepository.GetUsuarioById(idUsuario);

        if(usuario != null)
        {
            return Ok(usuario);
        } else
        {
            return NotFound();
        }
    }

    [HttpPut("ModificarUsuario")]
    public ActionResult<Usuario> UpdateNombreUsuario(int idUsuario, string nombre)
    {
        Usuario usuario = usuarioRepository.GetUsuarioById(idUsuario);
        usuario.NombreDeUsuario = nombre;

        usuarioRepository.UpdateUsuario(idUsuario, usuario);
        return Ok(usuario);
    }  
}
