namespace ColorChessConsole;

public class Map
{
    public Cell[,] cells = null;
    public List<Player> players = new List<Player>();
    public List<int> scorePlayer = new List<int>();

    public Map() { }

    public Map(Cell[,] _cells, List<Player> _players)
    {
        this.cells = _cells;
        this.players = _players;
    }

    public Cell GetCell(Position posCell)
    {
        return cells[posCell.X, posCell.Y];
    }

    public Cell GetCell(int x, int y)
    {
        return cells[x, y];
    }

    public int Width { get { return cells.GetLength(0); } }
    public int Lenght { get { return cells.GetLength(1); } }

    public Map(Map anotherMap)
    {
        cells = new Cell[anotherMap.Width, anotherMap.Lenght];

        for (int i = 0; i < anotherMap.Width; i++)
        {
            for (int j = 0; j < anotherMap.Lenght; j++)
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
            for (int j = 0; j < Lenght; j++)
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
