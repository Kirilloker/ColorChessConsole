using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
public class FigureBuilder
{
    protected Figure figure;

    public FigureBuilder()
    {
        figure = new Figure();
    }

    public Figure GetResult()
    {
        return figure;
    }

    public void SetPosition(Position _position)
    {
        figure.pos = _position;
    }


    public void SetPlayer(Player _player)
    {
        figure.player = _player;
    }

    public virtual void SetFigRequire()
    {

    }

    public virtual void SetFigType()
    {

    }

}
