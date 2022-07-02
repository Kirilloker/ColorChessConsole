namespace ColorChessConsole;

public class Cell
{
    //CellView cellView;

    Position pos;

    private int numberPlayer;
    private CellType type;
    private FigureType figureType;

    private Cell() { }

    public Cell(Position pos)
    {
        this.pos = pos;
        this.numberPlayer = -1;
        this.Type = CellType.Empty;
        this.figureType = FigureType.Empty;
    }

    public Cell(Cell anotherCell)
    {
        this.pos = new Position(anotherCell.pos);
        this.numberPlayer = anotherCell.numberPlayer;
        this.type = anotherCell.type;
        this.figureType = anotherCell.figureType;
    }


    public void Click()
    {
    }

    public void ShowPrompt()
    {
    }

    public void HidePrompt()
    {
    }

    public void ChangeColor()
    {
    }

    public bool Avaible(Dictionary<CellType, bool>[] require, int numberPlayerFigure)
    {
        // Может ли фигура наступить на такой тип клетки
        if (numberPlayer == numberPlayerFigure) return require[0][type];
        else return require[1][type];
    }



    // Свойства
    public int NumberPlayer
    {
        get{ return numberPlayer; }
        set
        {
            numberPlayer = value;	
            //cellView.Update();
        }
    }

    public CellType Type
    {
        get { return type; }
        set
        {
            type = value;
            //cellView.Update();
        }
    }
    public FigureType FigureType
    {
        get { return figureType; }
        set
        {
            figureType = value;
        }
    }

    // Для Логов
    public override string ToString()
    {
        string Logs = "";

        Logs += "Position: " + pos.ToString() + "\n";

        Logs += "Type: " + type.ToString() + "\n";

        Logs += "Number Player: " + numberPlayer + "\n";

        Logs += "Figure: " + figureType.ToString() + "\n";

        return Logs;
    }

}