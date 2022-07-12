namespace ColorChessConsole;

public class Figure
{
    public Position? pos;
    public FigureType type;
    public Player? player;
    public Dictionary<CellType, bool>[]? require;
    

    public Figure() { }

    public Figure(Figure anotherFigure, Player newPlayer)
    {
        this.pos = new Position(anotherFigure.pos);
        this.type = anotherFigure.type;
        this.player = newPlayer;
        this.require = anotherFigure.require;
        //FigureView?
    }

    public int Number
    {
        get { return player.number; }
    }


    public override string ToString()
    {
        string Logs = "";

        Logs += "Position: " + pos.ToString() + "\n";

        Logs += "Type: " + Types.ToString(type) + "\n";

        Logs += "Number Player: " + Number.ToString() + "\n";

        return Logs;
    }
}
