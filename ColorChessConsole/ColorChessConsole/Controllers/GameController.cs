using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;

class GameController
{
    public void OnCellOnClick(int x, int y)
    {
        Console.WriteLine("Some logic... with cell" + x + y);
    }
}