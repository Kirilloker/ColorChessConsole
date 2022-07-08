﻿namespace ColorChessConsole;

public class Cell
{
    private CellView cellView;
    private CellController controller;

    public Position pos;
    public int numberPlayer;
    public CellType type;
    public Figure figure;

    private Cell() { }

    public Cell(Position pos)
    {
        this.pos = pos;
        this.numberPlayer = -1;
        this.type = CellType.Empty;
        this.figure = null;

        //this.controller = CellController.Instance();
    }

    public Cell(Cell anotherCell)
    {
        this.pos = new Position(anotherCell.pos);
        this.numberPlayer = anotherCell.numberPlayer;
        this.type = anotherCell.type;
        this.figure = anotherCell.figure;
        //this.controller = CellController.Instance();
    }


    public void Click()
    {

    }

    public void StatePrompt(bool statePrompt)
    {
        cellView.StatePrompt(statePrompt);
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