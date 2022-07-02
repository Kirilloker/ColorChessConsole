namespace ColorChessConsole;
class CellOnClickNotification : ICommand
{
    private MediatorController reciver;
    private Position pos;

    public CellOnClickNotification(Position _pos)
    {
        pos = _pos;
        reciver = MediatorController.Instance();
    }

    public void Execute()
    {
        reciver.OnCellClicked(pos);
    }
}