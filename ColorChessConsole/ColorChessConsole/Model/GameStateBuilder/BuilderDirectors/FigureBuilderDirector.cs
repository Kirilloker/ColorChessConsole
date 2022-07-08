using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
class FigureBuilderDirector
{
    private FigureBuilder? builder;

    public FigureBuilderDirector() { }

    private void SetBuilder(FigureType figureType)
    {
        switch (figureType)
        {
            case FigureType.Pawn:
                builder = new PawnBuilder();
                break;
            case FigureType.King:
                builder = new KingBuilder();
                break;
            case FigureType.Bishop:
                builder = new BishopBuilder();
                break;
            case FigureType.Castle:
                builder = new CastleBuilder();
                break;
            case FigureType.Horse:
                builder = new HorseBuilder();
                break;
            case FigureType.Queen:
                builder = new QueenBuilder();
                break;
            default:
                break;
        }

    }

    public Figure MakeFigure(Position pos, Player player, FigureType figureType)
    {
        SetBuilder(figureType);

        builder.SetFigRequire();
        builder.SetFigType();
        builder.SetPosition(pos);
        builder.SetPlayer(player);

        return builder.GetResult(); 
    }
}