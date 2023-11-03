using Kanban.Models;
using System.Data.SQLite;
using System.Diagnostics;
namespace Kanban.Repository

public class UsuarioRepository : IUsuarioRepository
{
    private string cadenaConexion = "Data Source:DB/tareas.db:Cache=Shared";
    public void CrearUsuario(Usuario usuarioNuevo)
    {
        var queryString = @"INSERT INTO Usuario (nombre_de_usuario) VALUES(@nombre);";

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();

            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@nombre", usuarioNuevo.NombreDeUsuario));
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
    public void ModificarUsuario(int idUsuario, Usuario usuarioModificar)
    {
        var queryString = @"UPDATE Usuario SET nombre_de_usuario = {@nombre};";

        
    }
    public List<Usuario> GetAll()
    {
        var queryString = @"SELECT * FROM Usuario;";
        List<Usuario> usuarios = new List<Usuario>();
        using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            connection.Open();

            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();                
                    usuarios.Add(usuario);
                }
            }
            connection.Close();
        }
        return usuarios;
    }
    public Usuario GetUsuario(int idUsuario)
    {
        return null;
    }
    public void EliminarUsuario(int idUsuario)
    {

    }

}

