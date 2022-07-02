using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class CellOnClickNotification : ICommand
{
    private MediatorController reciver;
    private int x;
    private int y;

    public CellOnClickNotification(int _x, int _y)
    {
        x = _x; 
        y = _y;
        reciver = MediatorController.Instance();
    }

    public void Execute()
    {
        reciver.OnCellClicked(x,y);
    }
}