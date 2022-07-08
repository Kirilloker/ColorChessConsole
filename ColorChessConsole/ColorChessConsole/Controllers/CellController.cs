namespace ColorChessConsole;
class CellController : ICommandInvoker
{
    private CellView? cell;
    
    public void setCell(CellView _cell)
    {
        cell = _cell;
    }


    #region CopyMoments

    private ICommand? command;
    static private CellController? instance;
    private readonly MediatorController mediator;

    public static CellController Instance()
    {
        if (instance == null)
        {
            instance = new CellController();
            return instance;
        }
        else
            return instance;
    }


    private CellController()
    {
        instance = this;
        mediator = MediatorController.Instance();
    }


    public void SendCommand()
    {
        command.Execute();
    }

    public void SetCommand(ICommand _command)
    {
        command = _command;
    }

    #endregion
}

