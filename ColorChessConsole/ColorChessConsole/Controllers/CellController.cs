namespace ColorChessConsole;
class CellController : ICommandInvoker
{
    private ICommand? command;
    private CellView? cell;
    private readonly MediatorController mediator;

    public CellController()
    {
        mediator = MediatorController.Instance();
    }

    public void setCell(CellView _cell)
    {
        cell = _cell;
    }
    public void SendCommand()
    {
        command.Execute();
    }

    public void SetCommand(ICommand _command)
    {
        command = _command;
    }
}

