using System.Collections.Generic;

namespace ColorChessConsole;

public class Map
{
    public Cell[,] cells = null;
    //List<Player> players = new List<Player>();

    private Map() { }

    public Map(Cell[,] _cells) // List<Player> _players
    {
        this.cells = _cells;
        //this.players = _players;
    }

    public Cell GetCell(Position posCell)
    {
        return cells[posCell.X, posCell.Y];
    }

    public Map(Map anotherMap)
    {
        cells = new Cell[anotherMap.cells.GetLength(0), anotherMap.cells.GetLength(1)];

        for (int i = 0; i < anotherMap.cells.GetLength(0); i++)
        {
            for (int j = 0; j < anotherMap.cells.GetLength(1); j++)
            {
                cells[i, j] = new Cell(anotherMap.cells[i, j]);
            }
        }

        // + Players

    }
}
