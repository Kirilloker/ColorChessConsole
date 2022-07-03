namespace ColorChessConsole;
class CameraController : ICommandInvoker
{


    #region CopyMoments

    private ICommand? command;
    static private CameraController? instance;
    private readonly MediatorController mediator;

    public static CameraController Instance()
    {
        if (instance == null)
        {
            instance = new CameraController();
            return instance;
        }
        else
            return instance;
    }


    private CameraController()
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
