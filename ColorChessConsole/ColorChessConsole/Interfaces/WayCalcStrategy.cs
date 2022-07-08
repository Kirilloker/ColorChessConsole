using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChessConsole;
interface WayCalcStrategy
{
    public List<Cell> AllSteps(Map _map, Figure _figure);
    public List<Cell> Way(Map map, Position startPos, Position endPos);
}

