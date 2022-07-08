namespace ColorChessConsole;

public class Figure
{
    public Position? pos;
    public FigureType? type;
    public Player? player;
    public Dictionary<CellType, bool>[]? require;
    //private FigureView;

    public Figure() { }

    public Figure(Figure anotherFigure)
    {
        this.pos = new Position(anotherFigure.pos);
        this.type = anotherFigure.type;
        this.player = anotherFigure.player;
        this.require = anotherFigure.require;
        //FigureView?
    }

    public int GetNumberPlayer() { return player.number; }
}
