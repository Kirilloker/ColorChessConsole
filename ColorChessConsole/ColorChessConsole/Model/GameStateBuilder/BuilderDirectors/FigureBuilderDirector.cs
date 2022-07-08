using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class FigureBuilderDirector
{
    private FigureBuilder? builder;

    public FigureBuilderDirector(FigureBuilder _builder) { }

    private void SetBuilder(FigureType figureType)
    {

    }

    public Figure MakeFigure(Position pos, Player player, FigureType figureType)
    {


        builder.SetFigRequire();
        builder.SetFigType();
        builder.SetPosition(pos);
        builder.SetPlayer(player);

        return builder.GetResult(); 
    }
}