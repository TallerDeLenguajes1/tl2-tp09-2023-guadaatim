using Kanban.Models;

namespace Kanban.Repository;

public interface ITableroRepository
{
    public void CreateTablero(Tablero tablero);
    public void UpdateTablero(int idTablero, Tablero tableroModificar);
    public List<Tablero> GetAllTablero();
    public List<Tablero> GetTableroByUsuario(int idUsuario);
    public void DeleteTablero(int idTablero);
}