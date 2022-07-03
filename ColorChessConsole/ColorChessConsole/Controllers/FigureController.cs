namespace ColorChessConsole;
class FigureController : ICommandInvoker
{


    #region CopyMoments

    private ICommand? command;
    static private FigureController? instance;

    public static FigureController Instance()
    {
        if (instance == null)
        {
            instance = new FigureController();
            return instance;
        }
        else
            return instance;
    }


    private FigureController()
    {
        instance = this;
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

