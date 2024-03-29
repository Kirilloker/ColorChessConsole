﻿namespace ColorChessConsole;

public class Map
{
    public Cell[,] cells = null;
    public List<Player> players = new List<Player>();
    public List<int> scorePlayer = new List<int>();

    // Добавить пустые клетки

    public Map() { }
    public Map(int x, int y) 
    {
        cells = new Cell[x, y];
    }

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
    public int Length { get { return cells.GetLength(1); } }

    public Map(Map anotherMap)
    {
        this.players = new List<Player>();

        for (int i = 0; i < anotherMap.players.Count; i++)
        {
            this.players.Add(new Player(anotherMap.players[i]));
        }

        cells = new Cell[anotherMap.Width, anotherMap.Length];

        for (int i = 0; i < anotherMap.Width; i++)
        {
            for (int j = 0; j < anotherMap.Length; j++)
            {
                cells[i, j] = new Cell(anotherMap.cells[i, j]);
            }
        }

        foreach (Player player in this.players)
        {
            foreach (Figure figure in player.figures)
            {
                this.cells[figure.pos.X, figure.pos.Y].figure = figure;
                //GetCell(figure.pos).figure = figure;
            }
        }

    }

    public override string ToString()
    {
        string Logs = "";

        Logs += "Cells:\n";

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Length; j++)
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
