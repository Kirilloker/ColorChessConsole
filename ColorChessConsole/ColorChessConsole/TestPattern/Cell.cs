namespace ColorChessConsole.TestPattern;

public class Cell
{
    Position myPos;
    
    public Cell(Position position)
    {
        myPos = position;
    }
    public void Click() 
    {
        Repartion.Instance().SendMessage(new Message(myPos), EnumTypes.GameManager, TypeEvent.ClickCell);
    }
}

