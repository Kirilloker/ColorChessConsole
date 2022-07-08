namespace ColorChessConsole.TestPattern;

public class GameManager
{
    static private GameManager? instance;

    public static GameManager Instance()
    {
        if (instance == null)
        {
            instance = new GameManager();
            return instance;
        }
        else
            return instance;
    }


    private GameManager()
    {
        instance = this;
    }

    public void ClickCell(Position position)
    {

    }


}
