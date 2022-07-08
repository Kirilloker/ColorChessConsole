using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
 class CellBuilder
 {
    private Cell cell;
    public CellBuilder() 
    {
        cell = new Cell();
    }

    public Cell MakeCell(Position pos, int numOfPlayer, CellType cellType, FigureType figureType)
    {
        cell.pos = pos;
        cell.numberPlayer = numOfPlayer;
        cell.figureType = figureType;
        cell.type = cellType;
        return cell;
    }
 }