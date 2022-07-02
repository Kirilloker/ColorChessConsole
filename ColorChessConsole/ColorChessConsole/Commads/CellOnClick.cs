namespace ColorChessConsole;
class CellOnClick : ICommand
{
    private GameController reciver;
    private Position pos;

    public CellOnClick(Position _pos, GameController _gameController)
    {
        pos = _pos;
        reciver = _gameController;
    }

    public void Execute()
    {
        reciver.OnCellOnClick(pos);
    }
}

