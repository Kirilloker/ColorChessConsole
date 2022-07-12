namespace ColorChessConsole;
class BishopAlgorithm : WayCalcStrategy
{
    public List<Cell> AllSteps(Map map, Figure figure)
    {
        List<Cell> avaibleCell = new List<Cell>();

        Position posFigure = figure.pos;


        for (int i = -3; i <= 3; i += 2)
        {
            for (int j = 0; j < map.Width; j++)
            {
                Position posCell = new Position(posFigure.X + j * (i % 2), posFigure.Y + j * (i % 2) * (Math.Abs(i) - 2));

                if (Check.OutOfRange(posCell, map) == true) { break; }
                if (Check.SelfPoint(posCell, posFigure) == true) { continue; }

                Cell cell = map.GetCell(posCell);

                if (Check.BusyCell(cell) == true
                    ||
                    Check.Avaible(posCell, figure, map) == false) { break; }

                avaibleCell.Add(cell);
            }

        }

        if (figure.pos.X == 1 && figure.pos.Y == 3)
        {
            for (int i = 0; i < avaibleCell.Count; i++)
            {
                if (avaibleCell[i].pos.X == 0 && avaibleCell[i].pos.Y == 3)
                {
                    Console.WriteLine("asd");
                }
            }
        }

        return avaibleCell;
    }

    public List<Cell> Way(Map map, Position startPos, Position endPos, Figure figure)
    {
        if (figure.pos.X == 1 && figure.pos.Y == 3 && endPos.X == 0 && endPos.Y == 3)
        {
            Console.WriteLine("");
        }

        List<Cell> way = new List<Cell>();

        for (int i = -3; i <= 3; i += 2)
        {
            way.Clear();

            for (float j = 0; j < map.Width; j++)
            {
                Position posCell = new Position((startPos.X + j * (i % 2)), (startPos.Y + j * (i % 2)  * (Math.Abs(i) - 2)));
                
                if (Check.OutOfRange(posCell, map) == true) { continue; }

                way.Add(map.GetCell(posCell));

                if (posCell == endPos) { return way; }
            }
        }



        return new List<Cell>();
    }

}

