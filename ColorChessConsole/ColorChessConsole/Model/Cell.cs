namespace ColorChessConsole;

public class Cell
{
    private CellView cellView;
    private CellController controller;

    public Position pos;
    public int numberPlayer;
    public CellType type;
    public FigureType figureType;

    private Cell() { }

    public Cell(Position pos)
    {
        this.pos = pos;
        this.numberPlayer = -1;
        this.type = CellType.Empty;
        this.figureType = FigureType.Empty;

        this.controller = CellController.Instance();
    }

    public Cell(Cell anotherCell)
    {
        this.pos = new Position(anotherCell.pos);
        this.numberPlayer = anotherCell.numberPlayer;
        this.type = anotherCell.type;
        this.figureType = anotherCell.figureType;
        this.controller = CellController.Instance();
    }


    public void Click()
    {
        controller.SetCommand(new CellOnClickNotification(pos));
        controller.SendCommand();
    }

    public void StatePrompt(bool statePrompt)
    {
        cellView.StatePrompt(statePrompt);
    }


    //public void ChangeColor()
    //{
    //}

    public bool Avaible(Dictionary<CellType, bool>[] require, int numberPlayerFigure)
    {
        // Может ли фигура наступить на такой тип клетки
        if (numberPlayer == numberPlayerFigure) return require[0][type];
        else return require[1][type];
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