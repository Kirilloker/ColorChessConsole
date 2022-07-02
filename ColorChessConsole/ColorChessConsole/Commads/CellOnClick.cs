using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class CellOnClick : ICommand
{
    private GameController reciver;
    private int x;
    private int y;

    public CellOnClick(int _x, int _y, GameController _gameController)
    {
        x = _x;
        y = _y;
        reciver = _gameController;
    }

    public void Execute()
    {
        reciver.OnCellOnClick(x, y);
    }
}

