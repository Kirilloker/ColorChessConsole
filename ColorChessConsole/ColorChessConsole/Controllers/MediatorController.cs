namespace ColorChessConsole;
class MediatorController : ICommandInvoker
{
    private CellController? cellController;
    private GameController? gameController;
    private ICommand? command;
    static private MediatorController? instance;

    public static MediatorController Instance()
    {
        if (instance == null)
        {
            instance = new MediatorController();
            return instance;
        }
        else
            return instance;
    }


    private MediatorController()
    {
        instance = this; 
    }

    public void setController(CellController _cellController)
    {
        cellController = _cellController;

    }
    public void setController(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void SendCommand()
    {
        command.Execute();
    }

    public void SetCommand(ICommand _command)
    {
        command = _command;
    }

    public void OnCellClicked(Position pos)
    {
        SetCommand(new CellOnClick(pos, gameController));
        SendCommand();
    }
}

