namespace ColorChessConsole.TestPattern;

public class Repartion
{
    GameManager gameManager = GameManager.Instance();

    static private Repartion? instance;

    public static Repartion Instance()
    {
        if (instance == null)
        {
            instance = new Repartion();
            return instance;
        }
        else
            return instance;
    }


    private Repartion()
    {
        instance = this;
    }


    public void SendMessage(Message message, EnumTypes recipient, TypeEvent typeEvent)
    {
        switch (recipient)
        {
            case EnumTypes.GameManager:
                SendMessageGameManager(message, typeEvent);
                break;
            default:
                break;
        }
    }
    
    public void SendMessageGameManager(Message message, TypeEvent typeEvent)
    {
        switch (typeEvent)
        {
            case TypeEvent.ClickCell:
                gameManager.ClickCell((Position)message.OutputDate());
                break;
            default:
                break;
        }
    }
}
