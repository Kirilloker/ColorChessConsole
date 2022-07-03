namespace ColorChessConsole;
class UIController : ICommandInvoker
{


    #region CopyMoments

    private ICommand? command;
    static private UIController? instance;
    private readonly MediatorController mediator;

    public static UIController Instance()
    {
        if (instance == null)
        {
            instance = new UIController();
            return instance;
        }
        else
            return instance;
    }


    private UIController()
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
