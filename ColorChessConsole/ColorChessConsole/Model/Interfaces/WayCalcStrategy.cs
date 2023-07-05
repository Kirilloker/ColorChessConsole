using System.Collections.Generic;
using ColorChessConsole.Model.GameState;

namespace ColorChessConsole.Model.Interfaces
{
    interface IWayCalcStrategy
    {
        public List<Cell> AllSteps(Map map, Figure figure);
        public List<Cell> Way(Map map, Position startPos, Position endPos, Figure figure);
    }
}