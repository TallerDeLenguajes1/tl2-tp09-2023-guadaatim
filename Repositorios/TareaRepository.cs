using Kanban.Models;
using System.Data.SQLite;
using System.Diagnostics;
namespace Kanban.Repository;

public class TareaRpository : ITareaRepository
{
    private string cadenaConexion = "Data Source:DB/tareas.db:Cache=Shared";

    public void CreateTarea(int idTablero) //devuelve tablero ???
    {
        var queryString = @"INSERT INTO Tarea () VALUES ();";

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();

            var command = new SQLiteCommand(queryString, connection);
            
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

     public void AsignarUsuario(int idUsuario, int idTarea)
    {
        throw new NotImplementedException();
    }

    public List<Tarea> GetAllTareaByTablero(int idTablero)
    {
        throw new NotImplementedException();
    }

    public List<Tarea> GetAllTareasByUsuario(int idUsuario)
    {
        throw new NotImplementedException();
    }

    public Tarea GetTareaById(int idTarea)
    {
        throw new NotImplementedException();
    }

    public void UpdateTarea(int idTarea, Tarea tareaModificar)
    {
        throw new NotImplementedException();
    }
    
    public void DeleteTarea(int idTarea)
    {
        var queryString = @"DELETE * FROM Tarea WHERE id = @idTarea;";

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idTarae", idTarea));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}