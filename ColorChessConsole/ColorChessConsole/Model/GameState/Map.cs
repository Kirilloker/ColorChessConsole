namespace ColorChessConsole;

public class Map
{
    public Cell[,] cells = null;
    public List<Player> players = new List<Player>();

    private Map() { }

    public Map(Cell[,] _cells, List<Player> _players)
    {
        this.cells = _cells;
        this.players = _players;
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

        List<Player> players = new List<Player>();

        for (int i = 0; i < anotherMap.players.Count; i++)
        {
            players.Add(new Player(anotherMap.players[i]));
        }
    }

    public override string ToString()
    {
        string Logs = "";

        Logs += "Cells:\n";

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                Logs += cells[i, j].ToString() + "\n";
            }
        }

        Logs += "Players:\n";

        for (int i = 0; i < players.Count; i++)
        {
            Logs += players[i].ToString() + "\n";
        }

        return Logs;
    }
}
