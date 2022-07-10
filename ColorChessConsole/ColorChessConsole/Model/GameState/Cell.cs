namespace ColorChessConsole;

public class Cell
{
    public Position pos;
    public CellType type;
    public int numberPlayer;
    public Figure figure;

    public Cell() { }

    public Cell(Position pos)
    {
        this.pos = pos;
        this.type = CellType.Empty;
        this.figure = null;
        numberPlayer = -1;
    }

    public Cell(Cell anotherCell)
    {
        this.pos = new Position(anotherCell.pos);
        this.type = anotherCell.type;
        this.figure = anotherCell.figure;
    }


    public FigureType FigureType
    {
        get
        {
            if (this.figure == null) return FigureType.Empty;
            return figure.type;
        }
    }




    public bool Avaible(Dictionary<CellType, bool>[] require, int numberPlayerFigure)
    {
        // Может ли фигура наступить на такой тип клетки

        // Если в словаре нет такого типа клетки, то сразу возвращаем False
        if ((require[0].ContainsKey(type) || require[1].ContainsKey(type)) == false)
        {
            return false;
        }

        if (numberPlayer == numberPlayerFigure) return require[0][type];
        else return require[1][type];
    }




    // Для Логов
    public override string ToString()
    {
        string Logs = "";

        Logs += "Position: " + pos.ToString() + "\n";

        Logs += "Type: " + Types.ToString(type) + "\n";

        Logs += "Number Player: " + numberPlayer.ToString() + "\n";

        Logs += "Figure: " + Types.ToString(figure.type) + "\n";

        return Logs;
    }

}