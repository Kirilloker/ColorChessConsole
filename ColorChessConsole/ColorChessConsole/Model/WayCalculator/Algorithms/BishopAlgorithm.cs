namespace ColorChessConsole;
class BishopAlgorithm : WayCalcStrategy
{
    public List<Cell> AllSteps(Map map, Figure figure)
    {
        List<Cell> avaibleCell = new List<Cell>();

        Position posFigure = figure.pos;


        for (int i = -3; i <= 3; i += 2)
        {
            for (int j = 0; j < map.cells.GetLength(0); j++)
            {
                Position posCell = new Position(posFigure.X + j * (i % 2), posFigure.Y + j * (i % 2) * (Math.Abs(i) - 2));

                if (Check.OutOfRange(posCell, map) == true) { break; }
                if (Check.SelfPoint(posCell, posFigure) == true) { continue; }

                Cell cell = map.GetCell(posCell);

                if (Check.BusyCell(cell) == true) { break; }

                if (Check.Avaible(posCell, figure, map) == false) { break; }

                avaibleCell.Add(cell);
            }

        }

        return avaibleCell;
    }

    public List<Cell> Way(Map map, Position startPos, Position endPos, Figure _figure)
    {
        bool Founded_way = false;

        List<Cell> way = new List<Cell>();

        for (int i = -3; i <= 3; i += 2)
        {
            if (Founded_way) { break; }

            way = new List<Cell>();

            for (float j = 0; j < map.cells.GetLength(0); j++)
            {
                Position newPos = new Position((startPos.X + j * (i % 2)), (startPos.Y + j * (i % 2)  * (Math.Abs(i) - 2)));
                way.Add(map.GetCell(newPos));


                if (newPos == endPos)
                {
                    Founded_way = true;
                    break;
                }
            }

            
        }
        return way;
    }

}

