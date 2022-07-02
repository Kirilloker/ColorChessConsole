namespace ColorChessConsole;
class UIController : ICommandInvoker
{
    private ICommand? command;

    public void SendCommand()
    {
        command.Execute();
    }

    public void SetCommand(ICommand _command)
    {
        command = _command;
    }
}
