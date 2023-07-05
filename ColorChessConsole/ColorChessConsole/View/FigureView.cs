using ColorChessConsole.Model;
using ColorChessConsole.Model.GameState;
using System.Collections;


public class FigureView 
{
    private FigureType type;
    private int numberPlayer;
    
    private FigureController figureController;

    
    public void SetType(FigureType _type)
    {
        type = _type;
    }

    public void SetNumberPlayer(int _numberPlayer)
    {
        numberPlayer = _numberPlayer;
    }

    public void SetFigureController(FigureController _figureController)
    {
        figureController = _figureController;
    }

    public Position Pos { 
        get 
        {
            return pos;
        } 
        set 
        {
            pos = value;
        }
    }

    private Position pos;

    public FigureType Type { get { return type; } }

    public int Number { get { return numberPlayer; } }
}
