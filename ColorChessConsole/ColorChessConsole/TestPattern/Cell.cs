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
        Repartion.Instance().SendMessage(new Message(myPos), TypeRecipient.GameManager, TypeEvent.ClickCell);
    }
}

