namespace ColorChessConsole;

class GameController
{
    public void OnCellOnClick(Position pos)
    {
        Console.WriteLine("Some logic... with cell" + pos.ToString());
    }
}