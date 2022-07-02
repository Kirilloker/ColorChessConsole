using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class CellView
{
    private int x;
    private int y;

    private CellController controller;

    public CellView(int _x, int _y, CellController _controller)
    {
        x = _x;
        y = _y;
        controller = _controller;
    }

    public void OnMouseClick()
    {
        controller.SetCommand(new CellOnClickNotification(x, y));
        controller.SendCommand();
    }
}
