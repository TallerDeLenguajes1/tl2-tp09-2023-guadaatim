using Kanban.Models;
using System.Data.SQLite;
using System.Diagnostics;
namespace Kanban.Repository;

public class TableroRepository : ITableroRepository
{
    private string cadenaConexion = "Data Source:DB/tareas.db:Cache=Shared";
    public void CreateTablero(Tablero tablero)
    {
        var queryString = @"INSERT INTO Tablero () VALUES ();";

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();

            var command = new SQLiteCommand(queryString, connection);
            
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public List<Tablero> GetAllTablero()
    {
        var queryString = @"SELECT * FROM Tablero;";
        List<Tablero> tableros = new List<Tablero>();

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            connection.Open();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tablero tablero = new Tablero();
                    tablero.Id = Convert.ToInt32(reader["id"]);
                    tablero.Nombre = reader["nombre"].ToString();
                    tablero.Descripcion = reader["descripcion"].ToString();
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tableros.Add(tablero);
                }
            }
            connection.Close();
        }
        return tableros;
    }
    public List<Tablero> GetTableroByUsuario(int idUsuario)
    {
        var queryString = @"SELECT * FROM Tablero WHERE id_usuario_propietario = @idUsuario;";
        List<Tablero> tableros = new List<Tablero>();

        using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            connection.Open();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tablero tablero = new Tablero();
                    tablero.Id = Convert.ToInt32(reader["id"]);
                    tablero.Nombre = reader["nombre"].ToString();
                    tablero.Descripcion = reader["descripcion"].ToString();
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tableros.Add(tablero);
                }
            }
            connection.Close();
        }
        return tableros;
    }
    public void UpdateTablero(int idTablero, Tablero tableroModificar)
    {
        var queryString = @"UPDATE Tablero SET WHERE id = @idUsuario;";

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(queryString, connection);

            command.Parameters.Add(new SQLiteParameter("@id", tableroModificar.Id));
            command.Parameters.Add(new SQLiteParameter("@nombre", tableroModificar.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tableroModificar.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@id_usuario_propietario", tableroModificar.IdUsuarioPropietario));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
    public void DeleteTablero(int idTablero)
    {
        var queryString = @"DELETE * FROM Tablero WHERE id = @idTablero;";

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}