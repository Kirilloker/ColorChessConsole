using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class CellView
{
    private Position pos;

    private CellController controller;

    public CellView(Position _pos, CellController _controller)
    {
        pos = _pos;
        controller = _controller;
    }

    public void OnMouseClick()
    {
        controller.SetCommand(new CellOnClickNotification(pos));
        controller.SendCommand();
    }
}
