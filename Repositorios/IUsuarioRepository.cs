using Kanban.Models;

namespace Kanban.Repository;

public interface IUsuarioRepository
{ 
    public void CrearUsuario(Usuario usuarioNuevo);
    public void ModificarUsuario(int idUsuario, Usuario usuarioModificar);
    public List<Usuario> GetAll();
    public Usuario GetUsuario(int idUsuario);
    public void EliminarUsuario(int idUsuario);
}
    